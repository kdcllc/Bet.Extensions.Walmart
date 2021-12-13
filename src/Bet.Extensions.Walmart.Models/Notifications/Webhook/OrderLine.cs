namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Orderline
{
    [JsonPropertyName("lineNumber")]
    public string? LineNumber { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("quantity")]
    public Quantity? Quantity { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("statusDate")]
    public DateTime StatusDate { get; set; }

    [JsonPropertyName("shippingProgramType ")]
    public string? ShippingProgramType { get; set; }

    [JsonPropertyName("shippingMethod")]
    public string? ShippingMethod { get; set; }
}
