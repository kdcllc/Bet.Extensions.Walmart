namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// Return type for Subscription Event delete.
/// </summary>
public class DeleteSubscriptionEvent
{
    /// <summary>
    /// Subscription Id of the subscription that is deleted.
    /// </summary>
    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    /// <summary>
    /// Message confirming that the subscription has been deleted. i.e. 'Successfully deleted subscription'.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

