namespace Bet.Extensions.Walmart.Models.Notifications.Webhook
{
    /// <summary>
    /// This notification is triggered when an offer is published.
    ///
    /// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
    /// </summary>
    public class OfferPublishedEvent
    {
        /// <summary>
        /// Event Meta information.
        /// </summary>
        [JsonPropertyName("source")]
        public EventSource? Source { get; set; }

        /// <summary>
        /// Event details.
        /// </summary>
        [JsonPropertyName("payload")]
        public OfferPublishedEventPayload? Payload { get; set; }
    }
}
