namespace Bet.Extensions.Walmart.Models.Items;

public class Payload
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("subcategory")]
    public SubCategory[]? SubCategories { get; set; }
}
