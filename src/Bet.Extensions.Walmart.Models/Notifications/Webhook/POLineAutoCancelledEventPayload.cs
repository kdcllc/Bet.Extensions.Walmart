namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order (PO) Line Auto-cancelled Event details.
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POLineAutoCancelledEventPayload : POCreatedEventPayload
{
    /// <summary>
    /// Purchase Order line information for each item.
    /// </summary>
    [JsonPropertyName("orderLines")]
    public new POLineAutoCancelledEventOrderLine[]? OrderLines { get; set; }
}
