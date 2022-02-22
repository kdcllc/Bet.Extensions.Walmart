namespace Bet.Extensions.Walmart.Models.Orders.Cancel;

public class OrderCancellation
{
    [JsonPropertyName("orderLines")]
    public OrderLineList? OrderLines { get; set; }
}
