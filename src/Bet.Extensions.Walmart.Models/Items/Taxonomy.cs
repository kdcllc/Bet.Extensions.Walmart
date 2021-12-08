namespace Bet.Extensions.Walmart.Models.Items;

public class Taxonomy
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("payload")]
    public Payload[]? Payloads { get; set; }
}

