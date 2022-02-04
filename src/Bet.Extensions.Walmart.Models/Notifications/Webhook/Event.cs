namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Event
{
    /// <summary>
    /// Event Meta information.
    /// </summary>
    [JsonPropertyName("source")]
    public EventSource? Source { get; set; }
}
