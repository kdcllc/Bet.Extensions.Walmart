using System.Text.Json;

using Bet.AspNetCore.Walmart.WebhookEvents;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Notifications.Webhook;

namespace WalmartWeb.EventHandlers;

public class POCreatedEventHandler : IWebhookEventHandler<POCreatedEvent>
{
    private readonly ILogger<POCreatedEventHandler> _logger;

    public POCreatedEventHandler(ILogger<POCreatedEventHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<WebhookEventResult> HandleEventAsync(
        POCreatedEvent @event,
        string eventName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var json = JsonSerializer.Serialize(@event, DefaultJsonSerializer.Options);

            _logger.LogInformation(json);
            return Task.FromResult(new WebhookEventResult());
        }
        catch (Exception ex)
        {
            return Task.FromResult(new WebhookEventResult(ex));
        }
    }
}
