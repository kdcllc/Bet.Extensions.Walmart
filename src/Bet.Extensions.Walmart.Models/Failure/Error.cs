namespace Bet.Extensions.Walmart.Models.Failure;

public class Error
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("field")]
    public string? Field { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("info")]
    public string? Info { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("errorIdentifiers")]
    public ErrorIdentifiers? ErrorIdentifiers { get; set; }
}


