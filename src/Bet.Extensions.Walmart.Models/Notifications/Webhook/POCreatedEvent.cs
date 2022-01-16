namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order (PO) Created Event.
///
/// This event occurs when there’s a new Purchase Order created for the seller.
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POCreatedEvent
{
    /// <summary>
    /// Event Meta information.
    /// </summary>
    [JsonPropertyName("source")]
    public EventSource? Source { get; set; }

    /// <summary>
    /// Event details.
    /// </summary>
    [JsonPropertyName("payload")]
    public POCreatedEventPayload? Payload { get; set; }
}
