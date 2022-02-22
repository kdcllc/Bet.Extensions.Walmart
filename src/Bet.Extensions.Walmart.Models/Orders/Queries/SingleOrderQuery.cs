namespace Bet.Extensions.Walmart.Models.Orders.Queries;

/// <summary>
/// This query is used with GetAsync methods.
/// </summary>
public class SingleOrderQuery
{
    /// <summary>
    /// The purchase order ID. One customer may have multiple purchase orders.
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; set; }

    /// <summary>
    /// Default: "false"
    /// Provides the image URL and product weight in response, if available.Allowed values are true or false.
    /// </summary>
    [JsonPropertyName("productInfo")]
    public bool? ProductInfo { get; set; }


    /// <summary>
    /// Default: "false"
    /// Provides additional attributes - originalCustomerOrderID, orderType - related to Replacement order, in response,
    /// if available.Allowed values are true or false.
    /// </summary>
    [JsonPropertyName("replacementInfo")]
    public bool? ReplacementInfo { get; set; }
}
