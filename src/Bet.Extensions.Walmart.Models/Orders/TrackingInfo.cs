namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// List of information about the package shipment and tracking updates.
/// </summary>
public class TrackingInfo
{
    /// <summary>
    /// The date the package was shipped.
    /// </summary>
    [JsonPropertyName("shipDateTime")]
    public long ShipDateTime { get; set; }

    /// <summary>
    /// Information about the package carrier(s).
    /// </summary>
    [JsonPropertyName("carrierName")]
    public CarrierName? CarrierName { get; set; }

    /// <summary>
    /// The shipping method. Can be one of the following: Standard, Express, OneDay, WhiteGlove, Value or Freight.
    /// </summary>
    [JsonPropertyName("methodCode")]
    public string? MethodCode { get; set; }

    /// <summary>
    /// TODO: find in docs???.
    /// </summary>
    [JsonPropertyName("carrierMethodCode")]
    public object? CarrierMethodCode { get; set; }

    /// <summary>
    /// The shipment tracking number.
    /// </summary>
    [JsonPropertyName("trackingNumber")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// The URL for tracking the shipment. This parameter is mandatory if the otherCarrier parameter is used.
    /// </summary>
    [JsonPropertyName("trackingURL")]
    public string? TrackingURL { get; set; }
}
