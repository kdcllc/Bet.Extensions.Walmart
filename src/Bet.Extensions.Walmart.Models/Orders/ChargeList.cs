namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// Information relating to the charge for the orderLine.
/// </summary>
public class ChargeList
{
    [JsonPropertyName("charge")]
    public Charge[]? Charge { get; set; }
}
