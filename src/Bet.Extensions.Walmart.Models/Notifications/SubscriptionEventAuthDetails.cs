namespace Bet.Extensions.Walmart.Models.Notifications;

/// <summary>
/// Authentication details for accessing the destination URL, if URL is protected.
///
/// <see href="https://developer.walmart.com/api/us/mp/notifications"/>.
/// </summary>
public class SubscriptionEventAuthDetails
{
    /// <summary>
    /// authHeaderName , using which authorization header will be passed.
    /// </summary>
    [JsonPropertyName("authHeaderName")]
    public string? AuthHeaderName { get; set; }

    /// <summary>
    /// enumeration: BASIC_AUTH,OAUTH,HMAC.
    /// </summary>
    [JsonPropertyName("authMethod")]
    public string? AuthMethod { get; set; }

    /// <summary>
    /// UserName to access destination URL.
    /// </summary>
    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    /// <summary>
    /// Password to access destination URL.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// OAUTH URL.
    /// </summary>
    [JsonPropertyName("authUrl")]
    public string? AuthUrl { get; set; }

    /// <summary>
    /// Client Secret for OAUTH URL / HMAC.
    /// </summary>
    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// ClientId for OAUTH URL.
    /// </summary>
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }
}
