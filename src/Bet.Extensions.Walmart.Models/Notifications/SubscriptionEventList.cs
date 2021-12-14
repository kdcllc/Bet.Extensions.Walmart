namespace Bet.Extensions.Walmart.Models.Notifications;


/// <summary>
/// Retunr an array of all subsriptions for the events.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEventList
{
    /// <summary>
    /// List of subsriptions.
    /// </summary>
    [JsonPropertyName("events")]
    public SubscriptionEvent[]? Events { get; set; }
}
