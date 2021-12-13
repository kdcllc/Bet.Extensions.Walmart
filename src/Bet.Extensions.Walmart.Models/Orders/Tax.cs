namespace Bet.Extensions.Walmart.Models.Orders;

/// <summary>
/// Tax information for the charge, including taxName and taxAmount.
/// </summary>
public class Tax
{
    /// <summary>
    /// The name associated with the tax. Example: 'Sales Tax'.
    /// </summary>
    [JsonPropertyName("taxName")]
    public string? TaxName { get; set; }

    /// <summary>
    /// The details for the amount of the tax charge.
    /// </summary>
    [JsonPropertyName("taxAmount")]
    public TaxAmount? TaxAmount { get; set; }
}
