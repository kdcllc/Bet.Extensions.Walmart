namespace Bet.Extensions.Walmart.Models.Authentication;

public class AuthScopes
{
    [JsonPropertyName("reports")]
    public string? Reports { get; set; }

    [JsonPropertyName("item")]
    public string? Item { get; set; }

    [JsonPropertyName("shipping")]

    public string? Shipping { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("lagtime")]
    public string? LagTime { get; set; }

    [JsonPropertyName("feeds")]
    public string? Feeds { get; set; }

    [JsonPropertyName("returns")]
    public string? Returns { get; set; }

    [JsonPropertyName("orders")]
    public string? Rrders { get; set; }

    [JsonPropertyName("rules")]
    public string? Rules { get; set; }

    [JsonPropertyName("fulfillment")]
    public string? Fulfillment { get; set; }

    [JsonPropertyName("inventory")]
    public string? Inventory { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
