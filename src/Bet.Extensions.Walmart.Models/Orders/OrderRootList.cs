namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderRootList
{

    [JsonPropertyName("list")]
    public OrderList? List { get; set; }
}
