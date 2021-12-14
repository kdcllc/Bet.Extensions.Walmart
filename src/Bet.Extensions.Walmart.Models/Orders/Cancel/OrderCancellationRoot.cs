namespace Bet.Extensions.Walmart.Models.Orders.Cancel;

public class OrderCancellationRoot
{
    [JsonPropertyName("orderCancellation")]
    public OrderCancellation? OrderCancellation { get; set; }
}
