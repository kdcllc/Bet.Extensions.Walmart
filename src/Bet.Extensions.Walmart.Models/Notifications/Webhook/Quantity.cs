namespace Bet.Extensions.Walmart.Models.Notifications.Webhook;

/// <summary>
/// Details about the quantity.
/// </summary>
public class Quantity
{
    /// <summary>
    /// Unit of measurement.
    /// </summary>
    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Quantity value.
    /// </summary>
    [JsonPropertyName("measurementValue")]
    public string? MeasurementValue { get; set; }
}
