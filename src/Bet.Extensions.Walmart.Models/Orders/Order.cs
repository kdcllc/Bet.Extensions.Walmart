using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

public class Order
{
    /// <summary>
    /// A unique ID associated with the seller's purchase order.
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    [Required]
    public string? PurchaseOrderId { get; set; }

    /// <summary>
    /// A unique ID associated with the sales order for specified customer.
    /// </summary>
    [JsonPropertyName("customerOrderId")]
    [Required]
    public string? CustomerOrderId { get; set; }

    /// <summary>
    /// The email address of the customer for the sales order.
    /// </summary>
    [JsonPropertyName("customerEmailId")]
    [Required]
    public string? CustomerEmailId { get; set; }

    /// <summary>
    /// The date the customer submitted the sales order.
    /// </summary>
    [JsonPropertyName("orderDate")]
    [Required]
    public long OrderDate { get; set; }

    /// <summary>
    /// The shipping information provided by the customer to the seller.
    /// </summary>
    [JsonPropertyName("shippingInfo")]
    [Required]
    public ShippingInfo? ShippingInfo { get; set; }

    /// <summary>
    /// A list of order lines in the order.
    /// </summary>
    [JsonPropertyName("orderLines")]
    [Required]
    public OrderLineList? OrderLines { get; set; }

    /// <summary>
    /// Specifies the type of shipNode.
    /// </summary>
    [JsonPropertyName("shipNode")]
    public ShipNode? ShipNode { get; set; }
}































