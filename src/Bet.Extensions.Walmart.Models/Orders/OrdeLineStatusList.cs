namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// A list of statuses for the Order Line.
/// </summary>
public class OrdeLineStatusList
{
    [JsonPropertyName("orderLineStatus")]
    public OrderLineStatus[]? OrderLineStatus { get; set; }
}
