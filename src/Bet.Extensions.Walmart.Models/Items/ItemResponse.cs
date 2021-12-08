namespace Bet.Extensions.Walmart.Models.Items;

public class ItemResponse
{
    [JsonPropertyName("ItemResponse")]
    public Item[]? Items { get; set; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; set; }

    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}
