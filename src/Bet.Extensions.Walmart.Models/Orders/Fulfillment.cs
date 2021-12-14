namespace Bet.Extensions.Walmart.Models.Orders;

public class Fulfillment
{
    /// <summary>
    /// Example : S2H, S2S, etc.
    /// </summary>
    [JsonPropertyName("fulfillmentOption")]
    public string? FulfillmentOption { get; set; }

    /// <summary>
    /// Example : Value, Expedited, Standard, Rush, etc.
    /// </summary>
    [JsonPropertyName("shipMethod")]
    public string? ShipMethod { get; set; }

    /// <summary>
    /// Store Id.
    /// </summary>
    [JsonPropertyName("StoreId")]
    public object? StoreId { get; set; }

    /// <summary>
    /// Gives pick up datetime information.
    /// </summary>
    [JsonPropertyName("pickUpDateTime")]
    public long PickUpDateTime { get; set; }

    /// <summary>
    /// Gives pick up by information.
    /// </summary>
    [JsonPropertyName("pickUpBy")]
    public object? PickUpBy { get; set; }

    /// <summary>
    /// Gives shipping program information. Examples TWO_DAY, THREE_DAY.
    /// </summary>
    [JsonPropertyName("shippingProgramType")]
    public string? ShippingProgramType { get; set; }
}
