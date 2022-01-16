namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Offer Published Event details.
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class OfferUnpublishedEventPayload : OfferPublishedEventPayload
{

    /// <summary>
    /// <para>
    ///   Reason for the item to be unpublished.
    ///   If there are multiple reasons for the item to be unpublished, all will be listed here.
    /// </para>
    ///
    /// <para>A unique Id which identifies the item. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>Name of the item. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>Category of the item. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>No. of offers on the item from all sellers. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>	Seller’s offer price on the item. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>Seller’s shipping price on the item. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>Reference price used for offer to be unpublished. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>	URL for the reference price. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// <para>Source of the reference price. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED</para>
    /// </summary>
    [JsonPropertyName("statusChangeReasons")]
    public Dictionary<string, string>? StatusChangeReasons { get; set; }

    /// <summary>
    /// Reference price used for offer to be unpublished.
    ///
    /// Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED.
    /// </summary>
    [JsonPropertyName("referencePrice")]
    public decimal ReferencePrice { get; set; }

    /// <summary>
    /// URL for the reference price. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED.
    /// </summary>
    [JsonPropertyName("referencePriceURL")]
    public string? ReferencePriceURL { get; set; }

    /// <summary>
    /// Source of the reference price. Received only if statusChangeReasons = REASONABLE_PRICE_NOT_SATISFIED.
    /// </summary>
    [JsonPropertyName("referencePriceType")]
    public string? ReferencePriceType { get; set; }
}
