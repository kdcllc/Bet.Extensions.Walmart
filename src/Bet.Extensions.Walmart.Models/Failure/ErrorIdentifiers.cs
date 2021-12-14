namespace Bet.Extensions.Walmart.Models.Failure;

public class ErrorIdentifiers
{
    [JsonPropertyName("entry")]
    public object[]? Entries { get; set; }
}
