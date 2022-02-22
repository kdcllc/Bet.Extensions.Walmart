namespace Bet.Extensions.Walmart.Models.Items;

public class Item
{
    [JsonPropertyName("mart")]
    public string? Mart { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("wpid")]
    public string? WpId { get; set; }

    [JsonPropertyName("gtin")]
    public string? GTIN { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("shelf")]
    public string? Shelf { get; set; }

    [JsonPropertyName("productType")]
    public string? ProductType { get; set; }

    [JsonPropertyName("price")]
    public ItemPrice? Price { get; set; }

    [JsonPropertyName("publishedStatus")]
    public string? PublishedStatus { get; set; }

    [JsonPropertyName("unpublishedReasons")]
    public ItemUnpublishedReasons? UnpublishedReasons { get; set; }

    [JsonPropertyName("lifecycleStatus")]
    public string? LifecycleStatus { get; set; }

    [JsonPropertyName("upc")]
    public string? UPC { get; set; }
}
