using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

public class StatusQuantity
{
    /// <summary>
    /// Enum: "EACH" "EA"  Unit of quantity.
    /// </summary>
    [JsonPropertyName("unitOfMeasurement")]
    [Required]
    public string? UnitOfMeasurement { get; set; }

    /// <summary>
    /// Always use '1'.
    /// </summary>
    [JsonPropertyName("amount")]
    [Required]
    public string? Amount { get; set; }
}

