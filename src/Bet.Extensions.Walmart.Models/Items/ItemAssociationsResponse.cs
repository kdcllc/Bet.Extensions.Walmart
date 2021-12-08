namespace Bet.Extensions.Walmart.Models.Items;


public class ItemAssociationsResponse
{
    [JsonPropertyName("items")]
    public ItemAssociations[]? Items { get; set; }
}
