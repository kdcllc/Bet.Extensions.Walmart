namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderList
{
    [JsonPropertyName("meta")]
    public OrderMeta Meta { get; set; }

    [JsonPropertyName("elements")]
    public OrderElements? Elements { get; set; }
}
