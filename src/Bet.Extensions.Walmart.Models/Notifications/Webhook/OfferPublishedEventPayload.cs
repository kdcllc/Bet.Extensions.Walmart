namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Offer Published Event details.
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class OfferPublishedEventPayload
{
    /// <summary>
    /// Seller’s Partner ID.
    /// </summary>
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; set; }

    /// <summary>
    /// A unique Id which identifies the item.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// Status of the item in the submission process.
    /// </summary>
    [JsonPropertyName("publishStatus")]
    public string? PublishStatus { get; set; }

    /// <summary>
    /// Status of the item in the overall lifecycle.
    /// </summary>
    [JsonPropertyName("lifecycleStatus")]
    public string? LifecycleStatus { get; set; }

    /// <summary>
    /// A unique Id that identifies the item.
    /// </summary>
    [JsonPropertyName("itemId")]
    public string? ItemId { get; set; }

    /// <summary>
    /// The item name.
    /// </summary>
    [JsonPropertyName("itemName")]
    public string? ItemName { get; set; }

    /// <summary>
    /// The item category.
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// The total number of offers.
    /// </summary>
    [JsonPropertyName("totalNumberOfOffers")]
    public int TotalNumberOfOffers { get; set; }

    /// <summary>
    /// The Seller Offer price.
    /// </summary>
    [JsonPropertyName("sellerOfferPrice")]
    public decimal SellerOfferPrice { get; set; }

    /// <summary>
    /// The Seller Shipping price.
    /// </summary>
    [JsonPropertyName("sellerShippingPrice")]
    public decimal SellerShippingPrice { get; set; }
}
