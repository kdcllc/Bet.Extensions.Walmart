using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// The shipping information provided by the customer to the seller.
/// </summary>
public class ShippingInfo
{
    /// <summary>
    /// The customer's phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    [Required]
    public string? Phone { get; set; }

    /// <summary>
    /// The estimated time and date for the delivery of the item. Format: yyyy-MM-ddThh:MM:ssZ Example: '2020-06-15T06:00:00Z'.
    /// </summary>
    [JsonPropertyName("estimatedDeliveryDate")]
    [Required]
    public long EstimatedDeliveryDate { get; set; }

    /// <summary>
    /// The estimated time and date when the item will be shipped. Format: yyyy-MM-ddThh:MM:ssZ Example: '2020-06-15T06:00:00Z'.
    /// </summary>
    [JsonPropertyName("estimatedShipDate")]
    [Required]
    public long EstimatedShipDate { get; set; }

    /// <summary>
    /// The shipping method. Can be one of the following: Standard, Express, OneDay, WhiteGlove, Value or Freight.
    /// </summary>
    [JsonPropertyName("methodCode")]
    [Required]
    public string? MethodCode { get; set; }

    [JsonPropertyName("postalAddress")]
    [Required]
    public PostalAddress? PostalAddress { get; set; }
}
