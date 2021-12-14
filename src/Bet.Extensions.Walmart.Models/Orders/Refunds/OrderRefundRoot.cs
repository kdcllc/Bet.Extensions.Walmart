namespace Bet.Extensions.Walmart.Models.Orders.Refunds;

public class OrderRefundRoot
{
    [JsonPropertyName("orderRefund")]
    public OrderRefund? OrderRefund { get; set; }
}
