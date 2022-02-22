namespace Bet.Extensions.Walmart.Models.Orders.Refunds;

public class OrderRefund
{
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; set; }

    [JsonPropertyName("orderLines")]
    public OrderLineList? OrderLines { get; set; }
}
