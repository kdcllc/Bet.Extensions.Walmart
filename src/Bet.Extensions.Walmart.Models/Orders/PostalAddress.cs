using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

public class PostalAddress
{
    /// <summary>
    /// The name for the person/place of shipping address.
    /// </summary>
    [JsonPropertyName("name")]
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// The first line of the shipping address.
    /// </summary>
    [JsonPropertyName("address1")]
    [Required]
    public string? Address1 { get; set; }

    /// <summary>
    /// The second line of the shipping address.
    /// </summary>
    [JsonPropertyName("address2")]
    [Required]
    public string? Address2 { get; set; }

    /// <summary>
    /// The city of the shipping address.
    /// </summary>
    [JsonPropertyName("city")]
    [Required]
    public string? City { get; set; }

    /// <summary>
    /// The state of the shipping address.
    /// </summary>
    [JsonPropertyName("state")]
    [Required]
    public string? State { get; set; }

    /// <summary>
    /// The zip code of the shipping address.
    /// </summary>
    [JsonPropertyName("postalCode")]
    [Required]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The country of the shipping address.
    /// </summary>
    [JsonPropertyName("country")]
    [Required]
    public string? Country { get; set; }

    /// <summary>
    /// The address type, example: 'RESIDENTIAL'.
    /// </summary>
    [JsonPropertyName("addressType")]
    public string? AddressType { get; set; }
}
