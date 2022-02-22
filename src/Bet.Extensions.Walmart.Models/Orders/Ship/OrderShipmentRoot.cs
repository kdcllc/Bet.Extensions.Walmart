namespace Bet.Extensions.Walmart.Models.Orders.Ship;

public class OrderShipmentRoot
{
    [JsonPropertyName("orderShipment")]
    public OrderShipment? OrderShipment { get; set; }
}
