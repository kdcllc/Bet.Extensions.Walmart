namespace Bet.Extensions.Walmart.Abstractions.Options;

public class WalmartOptions
{
    /// <summary>
    /// Walmart Client ID to generate please login into:
    /// <see href="https://developer.walmart.com/account/generateKey"/>.
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Walmart Client Secret to generate please login into:
    /// <see href="https://developer.walmart.com/account/generateKey"/>.
    /// </summary>
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// Base Url for the Walmart Apis.
    /// </summary>
    public Uri BaseUrl => IsSandBox ? new Uri("https://sandbox.walmartapis.com/") : new Uri("https://marketplace.walmartapis.com/");

    /// <summary>
    /// Specify if sandbox is used.
    /// </summary>
    public bool IsSandBox { get; set; }

    /// <summary>
    /// Custom Url, for mock servers.
    /// </summary>
    public Uri? CustomUrl { get; set; }

    public string Version { get; set; } = "v3";

    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);

    public int Retry { get; set; } = 3;

    public Func<Exception, bool>? OnDataErrorThrowEx { get; set; } = (ex) => false;
}
