namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// A list of order lines in the order.
/// </summary>
public class OrderLineList
{
    [JsonPropertyName("orderLine")]
    public OrderLine[]? OrderLine { get; set; }
}
