namespace Bet.Extensions.Walmart.Models.Orders;

public class RefundChargeList
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("refundCharge")]
    RefundCharge[]? RefundCharge { get; set; }
}
