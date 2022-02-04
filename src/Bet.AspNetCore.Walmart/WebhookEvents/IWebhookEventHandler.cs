namespace Bet.AspNetCore.Walmart.WebhookEvents;

/// <summary>
/// The generic way to proccess Walmart Events.
/// </summary>
/// <typeparam name="TEvent">Tje actual event.</typeparam>
public interface IWebhookEventHandler<TEvent> where TEvent : class
{
    /// <summary>
    /// A Handler for the Walmart Webhook Events.
    /// </summary>
    /// <param name="event">The actual event.</param>
    /// <param name="eventName">The event name of the Walmart Webhook notification.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<WebhookEventResult> HandleEventAsync(TEvent @event, string eventName, CancellationToken cancellationToken = default);
}
