namespace Bet.Extensions.Walmart.Models.Orders;

public class RefundCharge
{
    /// <summary>
    /// Enum:
    /// "BillingError"
    /// "TaxExemptCustomer"
    /// "ItemNotAsAdvertised"
    /// "IncorrectItemReceived"
    /// "CancelledYetShipped"
    /// "ItemNotReceivedByCustomer"
    /// "IncorrectShippingPrice"
    /// "DamagedItem"
    /// "DefectiveItem"
    /// "CustomerChangedMind"
    /// "CustomerReceivedItemLate"
    /// "Missing Parts / Instructions"
    /// "Finance -> Goodwill"
    /// "Finance -> Rollback"
    /// "Buyer canceled"
    /// "Customer returned item"
    /// "General adjustment"
    /// "Merchandise not received"
    /// "Quality -> Missing Parts / Instructions"
    /// "Shipping & Delivery -> Damaged"
    /// "Shipping & Delivery -> Shipping Price Discrepancy" "Others".
    /// </summary>
    [JsonPropertyName("refundReason")]
    public string? RefundReason { get; set; }

    /// <summary>
    /// List of elements that make up a charge.
    /// </summary>
    [JsonPropertyName("charge")]
    public Charge? Charge { get; set; }
}
