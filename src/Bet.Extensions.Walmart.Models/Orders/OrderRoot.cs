namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderRoot
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
}
