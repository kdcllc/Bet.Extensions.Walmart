namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderElements
{
    [JsonPropertyName("order")]
    public Order[]? Orders { get; set; }
}
