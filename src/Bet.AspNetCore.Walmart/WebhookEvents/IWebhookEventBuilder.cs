using Microsoft.Extensions.DependencyInjection;

namespace Bet.AspNetCore.Walmart.WebhookEvents;

public interface IWebhookEventBuilder
{
    /// <summary>
    /// Dependency Injection Container.
    /// </summary>
    IServiceCollection Services { get; }

    /// <summary>
    /// Add Walmart Webhook Event Handler.
    /// </summary>
    /// <typeparam name="THandler">The webhook handler.</typeparam>
    /// <typeparam name="TEvent">The webhook event type.</typeparam>
    /// <param name="eventName">
    /// The event name for walmart webhook event i.e 'OFFER_UNPUBLISHED', 'PO_LINE_AUTOCANCELLED', 'PO_CREATED'
    ///
    /// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.</param>
    /// <returns></returns>
    IWebhookEventBuilder AddWebhookEvent<THandler, TEvent>(string eventName)
        where THandler : class, IWebhookEventHandler<TEvent>
        where TEvent : class;
}
