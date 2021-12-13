namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

public class Quantity
{
    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; set; }

    [JsonPropertyName("measurementValue")]
    public string? MeasurementValue { get; set; }
}
