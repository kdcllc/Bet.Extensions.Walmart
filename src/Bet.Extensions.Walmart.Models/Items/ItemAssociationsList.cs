namespace Bet.Extensions.Walmart.Models.Items;


public class ItemAssociationsList
{
    [JsonPropertyName("items")]
    public ItemAssociations[]? Items { get; set; }
}
