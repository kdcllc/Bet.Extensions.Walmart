namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderMeta
{

    [JsonPropertyName("totalCount")]

    public int TotalCount { get; set; }

    [JsonPropertyName("limit")]

    public int Limit { get; set; }

    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}
