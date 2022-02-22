namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// The details for the amount of the tax charge.
/// </summary>
public class ChargeAmount
{
    /// <summary>
    /// The type of currency for the charge. Example: USD for US Dollars.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// The numerical amount for that charge. Example: 9.99.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
