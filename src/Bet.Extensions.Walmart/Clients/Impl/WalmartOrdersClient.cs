using System.Net.Http.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Extensions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models.Orders;
using Bet.Extensions.Walmart.Models.Orders.Queries;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Walmart.Clients.Impl;

internal class WalmartOrdersClient : IWalmartOrdersClient
{
    private readonly IWalmartBaseClient _client;
    private readonly ILogger<WalmartOrdersClient> _logger;
    private readonly WalmartOptions _options;
    private readonly string _baseUrl;

    public WalmartOrdersClient(
          IWalmartBaseClient client,
        IOptions<WalmartOptions> options,
        ILogger<WalmartOrdersClient> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _options = options.Value;

        _baseUrl = $"/{_options.Version}/orders/";
    }

    public async IAsyncEnumerable<Order> ListAllAsync(OrderQuery query, CancellationToken cancellationToken)
    {
        string? cursor = string.Empty;

        var parameters = query.ToKeyValuePair();
        var url = parameters.CompileRequestUri(_baseUrl);
        var total = 0;

        do
        {
            var requestUri = url;

            if (!string.IsNullOrEmpty(cursor))
            {
                requestUri = $"{_baseUrl}{cursor}";
            }

            var response = await _client.HttpClient.GetFromJsonAsync<OrderRootList>(requestUri, cancellationToken);
            cursor = response?.List?.Meta.NextCursor;
            total = response?.List?.Meta?.TotalCount ?? 0;

            if (response?.List?.Elements?.Orders != null)
            {
                foreach (var item in response.List.Elements.Orders)
                {
                    yield return item;
                }
            }
        }
        while (!string.IsNullOrEmpty(cursor));

        _logger.LogDebug("{url} - {totalCount}", url, total);
    }
}
