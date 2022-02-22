namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// Header required for accessing the destination URL.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEventHeader
{
    [JsonPropertyName("contenttype")]
    public string? ContentType { get; set; }
}
