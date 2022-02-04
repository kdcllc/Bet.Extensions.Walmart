using System.Text;
using System.Text.Json;

using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Notifications.Webhook;
using Bet.Extensions.Walmart.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Bet.AspNetCore.Walmart.WebhookEvents.Internal;

public class WebookEventMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _sp;
    private readonly ILogger<WebookEventMiddleware> _logger;

    public WebookEventMiddleware(
        RequestDelegate next,
        IServiceProvider sp,
        ILogger<WebookEventMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _sp = sp ?? throw new ArgumentNullException(nameof(sp));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var options = _sp.GetRequiredService<IOptionsMonitor<WebhookEventOptions>>().Get(nameof(WebhookEventOptions));

        // check for the route and method.
        if (context.Request.Path != options.HttpRoute
            || context.Request.Method != options.HttpMethod)
        {
            await _next(context);
            return;
        }

        // authorize the call
        if (!IsAuthorize(context, options))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        if (!context.Request.HasJsonContentType())
        {
            context.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
            return;
        }

        var cts = CancellationTokenSource.CreateLinkedTokenSource(context.RequestAborted);

        var response = context.Response;

        try
        {
            var ser = _sp.GetRequiredService<IWebhookSerializer<Event>>();
            var registrations = _sp.GetRequiredService<IOptions<WebhookEventRegistrationOptions>>().Value;

            using var bodyReader = new StreamReader(context.Request.Body);
            var json = await bodyReader.ReadToEndAsync().ConfigureAwait(false);

            var @event = ser.GetEvent(json, DefaultJsonSerializer.Options);
            var eventName = @event?.Source?.EventType ?? string.Empty;

            var webhookEvent = registrations.WebHooksEventRegistrations.FirstOrDefault(x => string.Equals(x.EventName, eventName, StringComparison.OrdinalIgnoreCase));

            if (webhookEvent != null)
            {
                _logger.LogInformation("Registration for Walmart Event: {eventName} was received.", eventName);

                var result = await TriggerWebhookEventAsync(json, eventName, webhookEvent, cts.Token);

                if (options.ThrowIfException
                        && result?.Exception != null)
                {
                    throw new AggregateException($"{nameof(WebookEventMiddleware)} raised exceptions.", result.Exception);
                }
            }
            else
            {
                _logger.LogWarning("Registration for Walmart Webhook Event: {eventName} wasn't found.", eventName);
            }
        }
        finally
        {
            cts?.Dispose();
        }

        response.ContentType = "application/json";
        response.StatusCode = StatusCodes.Status200OK;
        await response.WriteAsync(string.Empty);
    }

    private bool IsAuthorize(HttpContext context, WebhookEventOptions options)
    {
        // authorization header
        var authHeader = context.Request.Headers["Authorization"];

        if (StringValues.IsNullOrEmpty(authHeader))
        {
            return false;
        }

        var basicEncodedHeader = authHeader.FirstOrDefault(x => x.Contains("Basic"));
        if (string.IsNullOrEmpty(basicEncodedHeader))
        {
            return false;
        }

        var basicHeader = Encoding.UTF8.GetString(Convert.FromBase64String(basicEncodedHeader.Replace("Basic", string.Empty).Trim()));

        var v = basicHeader.Split(":");

        if (v[0] == options.UserName && v[1] == options.Password)
        {
            return true;
        }

        return false;
    }

    private async Task<WebhookEventResult> TriggerWebhookEventAsync(
        string json,
        string eventName,
        WebhookEventRegistration webhookEvent,
        CancellationToken cancellationToken)
    {
        try
        {
            var e = JsonSerializer.Deserialize(json, webhookEvent.EventType, DefaultJsonSerializer.Options);

            using var scope = _sp.CreateScope();
            var service = webhookEvent.HandlerFactory(scope.ServiceProvider);

            var method = webhookEvent.HandlerType.GetMethod("HandleEventAsync");
            return await (Task<WebhookEventResult>)method.Invoke(service, parameters: new object[] { e, eventName, cancellationToken });
        }
        catch (Exception ex)
        {
            return new WebhookEventResult(ex);
        }
    }
}
