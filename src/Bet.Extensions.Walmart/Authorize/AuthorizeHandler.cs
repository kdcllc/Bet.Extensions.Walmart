using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Authentication;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Walmart.Authorize;

public class AuthorizeHandler : DelegatingHandler
{
    private readonly WalmartOptions _options;
    private readonly SemaphoreSlim _sem = new(1);
    private readonly ILogger<AuthorizeHandler> _logger;
    private string? _accessToken;
    private DateTimeOffset? _expirationTime;

    public AuthorizeHandler(
        IOptions<WalmartOptions> options,
        ILogger<AuthorizeHandler> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var activity = new Activity(nameof(AuthorizeHandler)).Start();

        request.Headers.Remove(WalmartHeaders.CorrelationId);
        request.Headers.Add(WalmartHeaders.CorrelationId, Activity.Current?.TraceId.ToString() ?? Guid.NewGuid().ToString());

        if (string.IsNullOrEmpty(_accessToken))
        {
            _logger.LogInformation("Authentication token is null. Attempting to Authenticate.");
            await _sem.WaitAsync(cancellationToken).ConfigureAwait(false);
            await AuthorizeAsync(request, cancellationToken).ConfigureAwait(false);
        }
        else if (_expirationTime?.Subtract(DateTimeOffset.UtcNow) < TimeSpan.FromMinutes(1))
        {
            _logger.LogInformation("Authentication token will expire in less than a minute. Attempting to Authenticate.");
            await _sem.WaitAsync(cancellationToken).ConfigureAwait(false);

            await AuthorizeAsync(request, cancellationToken).ConfigureAwait(false);
        }

        request.Headers.Remove(WalmartHeaders.AccessToken);
        request.Headers.Add(WalmartHeaders.AccessToken, _accessToken);

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        // is still unathenticated?
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _logger.LogInformation("The API returned 401 using the Authentication token. Attempting to Authenticate.");

            // going to request refresh token: enter or start wait
            await _sem.WaitAsync(cancellationToken).ConfigureAwait(false);

            // retry do to token request
            await AuthorizeAsync(request, cancellationToken).ConfigureAwait(false);

            // retry actual request with new tokens
            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        activity.Stop();

        return response;
    }

    private async Task AuthorizeAsync(HttpRequestMessage request, CancellationToken cancellation)
    {
        try
        {
            var data = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_options.BaseUrl}{_options.Version}/token")
            {
                Content = data
            };

            requestMessage.Headers.Add("Accept", "application/json");

            var authHeader = $"{_options?.ClientId}:{_options?.ClientSecret}"?.ToBase64String();

            requestMessage.Headers.Add("Authorization", $"Basic {authHeader}");

            requestMessage.Headers.Add(WalmartHeaders.ServiceName, nameof(AuthorizeHandler));

            requestMessage.Headers.Add(WalmartHeaders.CorrelationId, Activity.Current?.TraceId.ToString());

            var response = await base.SendAsync(requestMessage, cancellation).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var content = (await response.Content.ReadAsStringAsync()) ?? string.Empty;

                throw new AuthorizeHandlerException(response.StatusCode, $"Failed to authenticate {request.RequestUri} {content}with API. Please check your credentials.");
            }

            var contentStream = await response.Content.ReadAsStreamAsync(cancellation);
            var result = await JsonSerializer.DeserializeAsync<AuthToken>(contentStream, DefaultJsonSerializer.Options, cancellation);

            if (result == null)
            {
                throw new AuthorizeHandlerException(response.StatusCode, $"Failed to authenticate {request.RequestUri} with API. Please check your credentials.");
            }

            _accessToken = result.AccessToken;
            _expirationTime = DateTimeOffset.UtcNow.AddSeconds(result.ExpiresIn);

            _logger.LogInformation("Authentication token authenticated successfully. Retrying request.");

            request.Headers.Remove(WalmartHeaders.AccessToken);
            request.Headers.Add(WalmartHeaders.AccessToken, _accessToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to Authenticate {requestUri}", request.RequestUri);
            throw;
        }
        finally
        {
            _sem.Release();
        }
    }
}
