using System.ComponentModel.DataAnnotations;

namespace Bet.Extensions.Walmart.Models.Orders;

public class OrderLineStatus
{
    /// <summary>
    /// Enum: "Created" "Acknowledged" "Shipped" "Delivered" "Cancelled" "Refund"
    /// Should be 'Created'.
    /// </summary>
    [JsonPropertyName("status")]
    [Required]
    public string? Status { get; set; }

    /// <summary>
    /// Details about the status update.
    /// </summary>
    [JsonPropertyName("statusQuantity")]
    [Required]
    public StatusQuantity? StatusQuantity { get; set; }

    /// <summary>
    /// If order is cancelled, cancellationReason will explain the reason.
    /// </summary>
    [JsonPropertyName("cancellationReason")]
    public string? CancellationReason { get; set; }

    /// <summary>
    /// List of information about the package shipment and tracking updates.
    /// </summary>
    [JsonPropertyName("trackingInfo")]
    public TrackingInfo? TrackingInfo { get; set; }

    /// <summary>
    /// Information about the center where the package shipment is returned.
    /// </summary>
    [JsonPropertyName("returnCenterAddress")]
    public ReturnCenterAddress? ReturnCenterAddress { get; set; }
}
