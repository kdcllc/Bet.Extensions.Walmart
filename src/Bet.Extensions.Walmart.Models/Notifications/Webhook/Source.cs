namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Source
{
    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    [JsonPropertyName("eventTime")]
    public DateTime EventTime { get; set; }

    [JsonPropertyName("eventId")]
    public string? EventId { get; set; }
}
