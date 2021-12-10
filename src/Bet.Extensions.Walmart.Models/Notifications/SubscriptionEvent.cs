namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// Event for which the subscription is created.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEvent
{
    /// <summary>
    /// Use this to get list of all subscriptions for a specific event type.
    /// Refer to Events section for list of available eventType.
    /// </summary>
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    /// <summary>
    /// Unique ID for the subscription that can be used for fetching details, editing or deleting the subscription.
    /// </summary>
    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    /// <summary>
    /// Partner ID of the seller who created the subscription.
    /// </summary>
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; set; }

    /// <summary>
    /// Version of the event type for which the subscription is created.
    /// </summary>
    [JsonPropertyName("eventVersion")]
    public string? EventVersion { get; set; }

    /// <summary>
    /// Delegated access scope that event type is mapped to.
    /// </summary>
    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    /// <summary>
    /// Destination URL where notification will be received by seller.
    /// </summary>
    [JsonPropertyName("eventUrl")]
    public string? EventUrl { get; set; }

    /// <summary>
    /// Headers required for accessing the destination URL.
    /// </summary>
    [JsonPropertyName("headers")]
    public SubscriptionEventHeader? Headers { get; set; }

    /// <summary>
    /// Authentication details for accessing the destination URL, if URL is protected.
    /// </summary>
    [JsonPropertyName("authDetails")]
    public SubscriptionEventAuthDetails? AuthDetails { get; set; }

    /// <summary>
    /// ACTIVE or INACTIVE status of the subscription.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
