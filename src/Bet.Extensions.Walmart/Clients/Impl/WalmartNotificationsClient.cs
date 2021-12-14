using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Notifications;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Walmart.Clients.Impl;

internal class WalmartNotificationsClient : IWalmartNotificationsClient
{
    private readonly IWalmartBaseClient _client;
    private readonly ILogger<WalmartNotificationsClient> _logger;
    private readonly WalmartOptions _options;
    private readonly string _baseUrl;

    public WalmartNotificationsClient(
                IWalmartBaseClient client,
                IOptions<WalmartOptions> options,
                ILogger<WalmartNotificationsClient> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _options = options.Value;

        _baseUrl = $"/{_options.Version}/webhooks/subscriptions/";
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<SubscriptionEvent>?> ListAllAsync(CancellationToken cancellationToken)
    {
        var response = await _client.HttpClient.GetFromJsonAsync<SubscriptionEventList>(_baseUrl, DefaultJsonSerializer.Options, cancellationToken);
        return response?.Events;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<SubscriptionEventType>?> ListAllEventTypesAsync(CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/webhooks/eventTypes/";

        var response = await _client.HttpClient.GetFromJsonAsync<SubscriptionEventTypeList>(requestUri, DefaultJsonSerializer.Options, cancellationToken);
        return response?.Events;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionEvent?> UpdateAsync(
        string subscriptionId,
        SubscriptionEvent subscription,
        CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{subscriptionId}";

        var jsonContent = JsonContent.Create(subscription, new MediaTypeHeaderValue("application/json"), DefaultJsonSerializer.Options);

        var response = await _client.HttpClient.PatchAsync(requestUri, jsonContent, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);
        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(UpdateAsync));
            return null;
        }

        return await JsonSerializer.DeserializeAsync<SubscriptionEvent>(content, DefaultJsonSerializer.Options, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionEvent?> CreateAsync(SubscriptionEvent subscription, CancellationToken cancellationToken)
    {
        var payload = new SubscriptionEventList { Events = (new List<SubscriptionEvent> { subscription }).ToArray() };

        var response = await _client.HttpClient.PostAsJsonAsync<SubscriptionEventList>(_baseUrl, payload, DefaultJsonSerializer.Options, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);
        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(CreateAsync));
            return null;
        }

        var result = await JsonSerializer.DeserializeAsync<SubscriptionEventList>(content, DefaultJsonSerializer.Options, cancellationToken);
        return result?.Events?.SingleOrDefault();
    }

    /// <inheritdoc/>
    public async Task<DeleteSubscriptionEvent?> DeleteAsync(string subscriptionId, CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{subscriptionId}";

        var response = await _client.HttpClient.DeleteAsync(requestUri, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);
        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(DeleteAsync));
            return null;
        }

        return await JsonSerializer.DeserializeAsync<DeleteSubscriptionEvent>(content, DefaultJsonSerializer.Options, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string?> TestAsync(SubscriptionEvent subscription, CancellationToken cancellationToken)
    {
        var requesrtUri = $"/{_options.Version}/webhooks/test/";

        var response = await _client.HttpClient.PostAsJsonAsync<SubscriptionEvent>(requesrtUri, subscription, cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);
        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(TestAsync));
            return null;
        }

        if (response != null)
        {
            return (await JsonDocument.ParseAsync(content, cancellationToken: cancellationToken)).RootElement.GetProperty("message").GetRawText();
        }

        return null;
    }
}
