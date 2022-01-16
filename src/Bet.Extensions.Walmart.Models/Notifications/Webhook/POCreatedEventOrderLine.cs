namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Purchase Order line information for each item.
/// 
/// <see href="https://developer.walmart.com/doc/us/us-mp/us-mp-notifications/"/>.
/// </summary>
public class POCreatedEventOrderLine
{
    /// <summary>
    /// The line number associated with the details for each individual item in the purchase order.
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public string? LineNumber { get; set; }

    /// <summary>
    /// A unique id which identifies the item.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// Name of the item.
    /// </summary>
    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    /// <summary>
    /// Details about the quantity.
    /// </summary>
    [JsonPropertyName("quantity")]
    public Quantity? Quantity { get; set; }

    /// <summary>
    /// Status of the order line. Example: CREATED.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Date of most recent status shown on the order.
    /// </summary>
    [JsonPropertyName("statusDate")]
    public DateTime StatusDate { get; set; }

    /// <summary>
    /// Gives shipping program information. Examples: TWO_DAY, THREE_DAY, etc.
    /// </summary>
    [JsonPropertyName("shippingProgramType")]
    public string? ShippingProgramType { get; set; }

    /// <summary>
    /// Shipping Method. Examples: Value, Expedited, Standard, etc.
    /// </summary>
    [JsonPropertyName("shippingMethod")]
    public string? ShippingMethod { get; set; }
}
