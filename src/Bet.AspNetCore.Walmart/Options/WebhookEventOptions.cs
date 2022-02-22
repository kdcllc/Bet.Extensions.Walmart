namespace Bet.AspNetCore.Walmart.WebhookEvents.Internal;

public class WebhookEventOptions
{
    public string HttpRoute { get; set; } = "/webhookevents";

    public string HttpMethod { get; set; } = "POST";

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool ThrowIfException { get; set; } = true;
}
