namespace Bet.Extensions.Walmart.Models.Items;

public class ItemUnpublishedReasons
{
    [JsonPropertyName("reason")]
    public string[]? Reason { get; set; }
}
