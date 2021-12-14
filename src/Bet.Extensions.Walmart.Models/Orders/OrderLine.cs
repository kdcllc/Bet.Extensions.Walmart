using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderLine
{
    /// <summary>
    /// The line number associated with the details for each individual item in the purchase order.
    /// </summary>
    [JsonPropertyName("lineNumber")]
    [Required]
    public string? LineNumber { get; set; }

    /// <summary>
    /// The information for the item on the orderLine.
    /// </summary>
    [JsonPropertyName("item")]
    [Required]
    public Item? Item { get; set; }

    /// <summary>
    /// Information relating to the charge for the orderLine.
    /// </summary>
    [JsonPropertyName("charges")]
    [Required]
    public ChargeList? Charges { get; set; }

    [JsonPropertyName("orderLineQuantity")]
    [Required]
    public OrderLineQuantity? OrderLineQuantity { get; set; }

    /// <summary>
    /// The date shown on the recent order status.
    /// </summary>
    [JsonPropertyName("statusDate")]
    [Required]
    public long StatusDate { get; set; }

    /// <summary>
    /// A list of statuses for the Order Line.
    /// </summary>
    [JsonPropertyName("orderLineStatuses")]
    [Required]
    public OrdeLineStatusList? OrderLineStatuses { get; set; }

    /// <summary>
    /// Details about any refund on the order.
    /// </summary>
    [JsonPropertyName("refund")]
    public object? Refund { get; set; }

    /// <summary>
    /// Ship method stamped at order line level when order is placed.
    /// </summary>
    [JsonPropertyName("originalCarrierMethod")]
    public string? OriginalCarrierMethod { get; set; }

    /// <summary>
    /// Reference line Id.
    /// </summary>
    [JsonPropertyName("referenceLineId")]
    public string? ReferenceLineId { get; set; }

    [JsonPropertyName("fulfillment")]
    public Fulfillment? Fulfillment { get; set; }

    [JsonPropertyName("intentToCancel")]
    public string? IntentToCancel { get; set; }
}
