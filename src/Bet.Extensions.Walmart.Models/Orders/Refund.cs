namespace Bet.Extensions.Walmart.Models.Orders;

public class Refund
{
    [JsonPropertyName("refundComments")]
    public string? RefundComments { get; set; }

    [JsonPropertyName("refundCharges")]
    public RefundChargeList? RefundCharges { get; set; }
}
