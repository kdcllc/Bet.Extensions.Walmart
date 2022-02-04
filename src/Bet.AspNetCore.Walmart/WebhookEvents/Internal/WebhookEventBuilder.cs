using Microsoft.Extensions.DependencyInjection;

namespace Bet.AspNetCore.Walmart.WebhookEvents.Internal;

internal class WebhookEventBuilder : IWebhookEventBuilder
{
    public WebhookEventBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }

    /// <summary>
    /// Add Walmart Webhook event based on the event name.
    /// </summary>
    /// <typeparam name="THandler">The type of the webhook handler.</typeparam>
    /// <typeparam name="TEvent">The type of the webhook event.</typeparam>
    /// <param name="eventName">The event name.</param>
    /// <returns></returns>
    public IWebhookEventBuilder AddWebhookEvent<THandler, TEvent>(string eventName)
               where TEvent : class
               where THandler : class, IWebhookEventHandler<TEvent>
    {
        Services.Configure<WebhookEventRegistrationOptions>(options =>
        {
            options.WebHooksEventRegistrations.Add(new WebhookEventRegistration(
                eventName,
                sp => ActivatorUtilities.GetServiceOrCreateInstance<THandler>(sp),
                typeof(THandler),
                typeof(TEvent)));
        });

        return this;
    }
}
