namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order (PO) Line Auto-cancelled Event.
///
/// This notification occurs when a Purchase Order Line is auto-cancelled by Walmart
///
/// if order is not updated to Shipped status with a valid tracking number
/// by Estimated Ship Date (ESD) + 8 calendar days
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POLineAutoCancelledEvent
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
    public POLineAutoCancelledEventPayload? Payload { get; set; }
}
