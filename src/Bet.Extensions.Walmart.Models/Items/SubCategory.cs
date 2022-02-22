namespace Bet.Extensions.Walmart.Models.Items;

public class SubCategory
{
    [JsonPropertyName("subCategoryName")]
    public string? SubCategoryName { get; set; }

    [JsonPropertyName("subCategoryId")]
    public string? SubCategoryId { get; set; }
}
