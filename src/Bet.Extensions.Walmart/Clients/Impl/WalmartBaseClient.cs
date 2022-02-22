using Bet.Extensions.Walmart.Abstractions;

namespace Bet.Extensions.Walmart.Clients.Impl;

internal sealed class WalmartBaseClient : IWalmartBaseClient
{
    public WalmartBaseClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public HttpClient HttpClient { get; }
}
