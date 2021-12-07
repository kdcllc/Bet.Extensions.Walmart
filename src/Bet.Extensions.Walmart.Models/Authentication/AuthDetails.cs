namespace Bet.Extensions.Walmart.Models.Authentication;

public class AuthDetails
{
    [JsonPropertyName("expire_at")]
    public string? ExpireAt { get; set; }

    [JsonPropertyName("issued_at")]
    public string? IssuedAt { get; set; }

    [JsonPropertyName("is_valid")]
    public bool IsValid { get; set; }

    [JsonPropertyName("is_channel_match")]
    public bool IsChannelMatch { get; set; }

    [JsonPropertyName("scopes")]
    public AuthScopes? Scopes { get; set; }
}
