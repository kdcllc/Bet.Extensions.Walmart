namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// An Event Type.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEventType
{
    /// <summary>
    /// Delegated access scope that event type is mapped to.
    /// </summary>
    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    /// <summary>
    /// Event that you want to subscribe to.
    /// </summary>
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    /// <summary>
    /// Version of the specific event type.
    /// </summary>
    [JsonPropertyName("eventVersion")]
    public string? EventVersion { get; set; }

    /// <summary>
    /// Description of the specific event type.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

