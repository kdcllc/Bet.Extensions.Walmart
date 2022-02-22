namespace Bet.Extensions.Walmart.Models.Orders;

public class Item
{
    /// <summary>
    /// The name of the product associated with the line item. Example: 'Kenmore CF1' or '2086883 Canister Secondary Filter Generic 2 Pack'.
    /// </summary>
    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    /// <summary>
    /// An arbitrary alphanumeric unique ID, assigned to each item in the item file.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// Optional. Web URL for the image of the item.
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Optional. Weight information for the item.
    /// </summary>
    [JsonPropertyName("weight")]
    public Weight? Weight { get; set; }
}
