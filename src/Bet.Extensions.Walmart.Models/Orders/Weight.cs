namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// Weight information for the item.
/// </summary>
public class Weight
{
    /// <summary>
    /// Numerical amount of weight parameter.
    /// </summary>
    [JsonPropertyName("value")]

    public string? Value { get; set; }

    /// <summary>
    /// Standard value of measurement of the item. Example: 'Pounds'.
    /// </summary>
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
