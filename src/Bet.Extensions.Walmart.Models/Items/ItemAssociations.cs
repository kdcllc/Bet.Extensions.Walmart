namespace Bet.Extensions.Walmart.Models.Items;

public class ItemAssociations
{
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("associations")]
    public Association[]? Associations { get; set; }
}
