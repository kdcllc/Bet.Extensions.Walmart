namespace Bet.AspNetCore.Walmart.WebhookEvents.Internal;

internal class WebhookEventRegistrationOptions
{
    public IList<WebhookEventRegistration> WebHooksEventRegistrations { get; } = new List<WebhookEventRegistration>();
}
