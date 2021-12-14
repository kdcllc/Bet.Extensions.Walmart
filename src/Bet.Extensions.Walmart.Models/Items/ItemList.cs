namespace Bet.Extensions.Walmart.Models.Items;

public class ItemList
{
    [JsonPropertyName("ItemResponse")]
    public Item[]? Items { get; set; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; set; }

    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}
