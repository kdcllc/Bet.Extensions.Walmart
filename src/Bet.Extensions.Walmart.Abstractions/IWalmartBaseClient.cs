namespace Bet.Extensions.Walmart.Abstractions;

public interface IWalmartBaseClient
{
    /// <summary>
    /// An instance of the <see cref="HttpClient"/> that has been configured to be used.
    /// </summary>
    HttpClient HttpClient { get; }
}
