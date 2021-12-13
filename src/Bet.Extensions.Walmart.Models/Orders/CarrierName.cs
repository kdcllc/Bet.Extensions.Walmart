namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// Information about the package carrier(s).
/// </summary>
public class CarrierName
{
    /// <summary>
    /// Other carrier name, When otherCarrier is used, trackingUrl must also be provided.
    /// </summary>
    [JsonPropertyName("otherCarrier")]
    public string? OtherCarrier { get; set; }

    /// <summary>
    /// The package shipment carrier. Valid entries are:
    /// UPS, USPS, FedEx, Airborne, OnTrac, DHL, LS (LaserShip),
    /// UDS (United Delivery Service), UPSMI (UPS Mail Innovations), FDX, PILOT, ESTES, SAIA,
    /// FDS Express, Seko Worldwide, HIT Delivery, FEDEXSP (FedEx SmartPost).
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }
}
