namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// Information about the center where the package shipment is returned.
/// </summary>
public class ReturnCenterAddress
{
    /// <summary>
    /// The name for the person/place of return address.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The first line of the return address.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// The second line of the return address.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// The city of the return address.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The state of the return address.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The country of the return address.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Phone of the center where the package shipment is returned.
    /// </summary>
    [JsonPropertyName("dayPhone")]
    public string? DayPhone { get; set; }

    /// <summary>
    /// Email of the center where the package shipment is returned.
    /// </summary>
    [JsonPropertyName("emailId")]
    public string? EmailId { get; set; }
}
