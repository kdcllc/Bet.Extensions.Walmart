namespace Bet.Extensions.Walmart.Models.Notifications.Webhook
{
    /// <summary>
    /// Offer Unpublished Event is when seller’s offer moves from Published status to Unpublished status.
    ///
    /// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
    /// </summary>
    public class OfferUnpublishedEvent
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
        public OfferUnpublishedEventPayload? Payload { get; set; }
    }
}
