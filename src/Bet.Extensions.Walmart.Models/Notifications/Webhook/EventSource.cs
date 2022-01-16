namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Event Meta information.
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class EventSource
{
    /// <summary>
    /// Event for which the notification is received.
    /// </summary>
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    /// <summary>
    /// Time at which the event occurs.
    /// </summary>
    [JsonPropertyName("eventTime")]
    public DateTime EventTime { get; set; }

    /// <summary>
    /// Unique Id of the event.
    /// </summary>
    [JsonPropertyName("eventId")]
    public string? EventId { get; set; }
}
