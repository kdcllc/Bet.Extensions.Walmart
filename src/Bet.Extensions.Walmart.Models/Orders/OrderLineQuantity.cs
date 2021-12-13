namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderLineQuantity
{
    [JsonPropertyName("unitOfMeasurement")]
    public string? UnitOfMeasurement { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
