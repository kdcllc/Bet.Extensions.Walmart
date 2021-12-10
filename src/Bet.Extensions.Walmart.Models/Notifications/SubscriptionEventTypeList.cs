namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// List of event types.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEventTypeList
{
    /// <summary>
    /// List of event types.
    /// </summary>
    [JsonPropertyName("events")]
    public SubscriptionEventType[]? Events { get; set; }
}
