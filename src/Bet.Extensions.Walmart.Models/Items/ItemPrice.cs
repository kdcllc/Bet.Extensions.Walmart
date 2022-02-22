namespace Bet.Extensions.Walmart.Models.Items;

public class ItemPrice
{
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("amount")]
    public float Amount { get; set; }
}
