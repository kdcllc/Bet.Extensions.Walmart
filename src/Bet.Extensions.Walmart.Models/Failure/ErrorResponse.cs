namespace Bet.Extensions.Walmart.Models.Failure;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public Error[]? Errors { get; set; }
}
