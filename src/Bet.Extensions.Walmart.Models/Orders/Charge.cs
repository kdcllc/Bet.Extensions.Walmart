namespace Bet.Extensions.Walmart.Models.Orders;

public class Charge
{
    /// <summary>
    /// The charge type for line items can be one of the following: PRODUCT or SHIPPING For details, refer to 'Charge Types'.
    /// </summary>
    [JsonPropertyName("chargeType")]
    public string? ChargeType { get; set; }

    /// <summary>
    /// If chargeType is PRODUCT, chargeName is Item Price. If chargeType is SHIPPING, chargeName is Shipping.
    /// </summary>
    [JsonPropertyName("chargeName")]
    public string? ChargeName { get; set; }

    /// <summary>
    /// The details for the amount of the tax charge.
    /// </summary>
    [JsonPropertyName("chargeAmount")]
    public ChargeAmount? ChargeAmount { get; set; }

    /// <summary>
    /// Tax information for the charge, including taxName and taxAmount.
    /// </summary>
    [JsonPropertyName("tax")]
    public Tax? Tax { get; set; }
}
