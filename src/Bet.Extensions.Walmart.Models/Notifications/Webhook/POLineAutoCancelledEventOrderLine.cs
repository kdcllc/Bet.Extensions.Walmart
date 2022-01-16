namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order line information for each item.
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POLineAutoCancelledEventOrderLine : POCreatedEventOrderLine
{
    /// <summary>
    /// Reason for cancellation of PO Line.
    /// </summary>
    [JsonPropertyName("cancellationReason")]
    public string? CancellationReason { get; set; }
}
