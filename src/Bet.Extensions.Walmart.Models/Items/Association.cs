namespace Bet.Extensions.Walmart.Models.Items;

public class Association
{
    [JsonPropertyName("shippingTemplate")]
    public ShippingTemplate? ShippingTemplate { get; set; }

    [JsonPropertyName("shipNodeName")]
    public string? ShipNodeName { get; set; }

    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; set; }
}
