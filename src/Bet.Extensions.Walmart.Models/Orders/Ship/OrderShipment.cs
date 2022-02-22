namespace Bet.Extensions.Walmart.Models.Orders.Ship;

public class OrderShipment
{
    [JsonPropertyName("orderLines")]
    public OrderLineList? OrderLines { get; set; }
}
