namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Event
{
    [JsonPropertyName("source")]
    public Source? Source { get; set; }

    [JsonPropertyName("payload")]
    public Payload? Payload { get; set; }
}
