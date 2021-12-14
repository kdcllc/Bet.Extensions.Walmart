namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Payload
{
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; set; }

    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; set; }

    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; set; }

    [JsonPropertyName("orderDate")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("estimatedDeliveryDate")]
    public DateTime EstimatedDeliveryDate { get; set; }

    [JsonPropertyName("estimatedShipDate")]
    public DateTime EstimatedShipDate { get; set; }

    [JsonPropertyName("orderLines")]
    public Orderline[]? OrderLines { get; set; }

    [JsonPropertyName("shipNodeType")]
    public string? ShipNodeType { get; set; }
}
