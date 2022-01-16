namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order (PO) Created Event. Event details
///
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POCreatedEventPayload
{
    /// <summary>
    /// Seller’s Partner ID.
    /// </summary>
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; set; }

    /// <summary>
    /// A unique ID associated with the seller’s purchase order.
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; set; }

    /// <summary>
    /// A unique ID associated with the sales order for specified customer.
    /// </summary>
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; set; }

    /// <summary>
    /// The date the customer submitted the sales order.
    /// </summary>
    [JsonPropertyName("orderDate")]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// The estimated time and date for the delivery of the item.
    /// </summary>
    [JsonPropertyName("estimatedDeliveryDate")]
    public DateTime EstimatedDeliveryDate { get; set; }

    /// <summary>
    /// The estimated time and date when the item will be shipped.
    /// </summary>
    [JsonPropertyName("estimatedShipDate")]
    public DateTime EstimatedShipDate { get; set; }

    /// <summary>
    /// Purchase Order line information for each item.
    /// </summary>
    [JsonPropertyName("orderLines")]
    public POCreatedEventOrderLine[]? OrderLines { get; set; }

    /// <summary>
    /// Specifies the type of shipNode. Possible values are: SellerFulfilled, WFSFulfilled and 3PLFulfilled.
    /// </summary>
    [JsonPropertyName("shipNodeType")]
    public string? ShipNodeType { get; set; }
}
