using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Extensions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Orders;
using Bet.Extensions.Walmart.Models.Orders.Cancel;
using Bet.Extensions.Walmart.Models.Orders.Queries;
using Bet.Extensions.Walmart.Models.Orders.Refunds;
using Bet.Extensions.Walmart.Models.Orders.Ship;

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

    /// <inheritdoc/>
    public async Task<Order?> GetAsync(string purchaseOrderId, CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{purchaseOrderId}";

        var response = await _client.HttpClient.GetFromJsonAsync<OrderRoot>(requestUri, cancellationToken);

        return response?.Order;
    }

    /// <inheritdoc/>
    public async Task<Order?> GetAsync(SingleOrderQuery query, CancellationToken cancellationToken)
    {
        var baseUrl = $"{_baseUrl}{query.PurchaseOrderId}";

        var parameters = query.ToKeyValuePair();
        var requestUri = parameters.CompileRequestUri(baseUrl);

        var response = await _client.HttpClient.GetFromJsonAsync<OrderRoot>(requestUri, cancellationToken);

        return response?.Order;
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Order> ListAllAsync(OrderQuery query, CancellationToken cancellationToken)
    {
        return ListOrdersAsync(_baseUrl, query, cancellationToken);
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Order> ListAllReleasedAsync(OrderQuery query, CancellationToken cancellationToken)
    {
        var baseUrl = $"{_baseUrl}released";
        return ListOrdersAsync(baseUrl, query, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Order?> AcknowledgeAsync(string purchaseOrderId, CancellationToken cancellationToken)
    {
        var requestUrl = $"{_baseUrl}{purchaseOrderId}/acknowledge";

        var stringContent = new StringContent(string.Empty);
        stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        var response = await _client.HttpClient.PostAsync(requestUrl, stringContent, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);

        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(AcknowledgeAsync));
            return null;
        }

        return (await JsonSerializer.DeserializeAsync<OrderRoot>(content, DefaultJsonSerializer.Options, cancellationToken)).Order;
    }

    /// <inheritdoc/>
    public async Task<Order?> ShipAsync(string purchaseOrderId, OrderShipment orderShipment, CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{purchaseOrderId}/shipping";

        var request = new OrderShipmentRoot { OrderShipment = orderShipment };

        var response = await _client.HttpClient.PostAsJsonAsync<OrderShipmentRoot>(requestUri, request, DefaultJsonSerializer.Options, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);

        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(ShipAsync));
            return null;
        }

        return (await JsonSerializer.DeserializeAsync<OrderRoot>(content, DefaultJsonSerializer.Options, cancellationToken))?.Order;
    }

    /// <inheritdoc/>
    public async Task<Order?> CancelAsync(string purchaseOrderId, OrderCancellation orderCancellation, CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{purchaseOrderId}/cancel";
        var requestData = new OrderCancellationRoot { OrderCancellation = orderCancellation };

        var response = await _client.HttpClient.PostAsJsonAsync<OrderCancellationRoot>(requestUri, requestData, DefaultJsonSerializer.Options, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);

        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(CancelAsync));
            return null;
        }

        return (await JsonSerializer.DeserializeAsync<OrderRoot>(content, DefaultJsonSerializer.Options, cancellationToken)).Order;
    }

    /// <inheritdoc/>
    public async Task<Order?> RefundAsync(OrderRefund orderRefund, CancellationToken cancellationToken)
    {
        var requestUri = $"{_baseUrl}{orderRefund.PurchaseOrderId}/refund";
        var requestData = new OrderRefundRoot { OrderRefund = orderRefund };

        var response = await _client.HttpClient.PostAsJsonAsync<OrderRefundRoot>(requestUri, requestData, DefaultJsonSerializer.Options, cancellationToken);

        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        var ex = await response.ValidateAsync(content, _options.OnDataErrorThrowEx, cancellationToken);

        if (ex != null)
        {
            _logger.LogError(ex, "{name}", nameof(CancelAsync));
            return null;
        }

        return (await JsonSerializer.DeserializeAsync<OrderRoot>(content, DefaultJsonSerializer.Options, cancellationToken)).Order;
    }

    private async IAsyncEnumerable<Order> ListOrdersAsync(string baseUrl, OrderQuery query, CancellationToken cancellationToken)
    {
        string? cursor = string.Empty;
        var parameters = query.ToKeyValuePair();
        var url = parameters.CompileRequestUri(baseUrl);

        var total = 0;

        do
        {
            var requestUri = url;

            if (!string.IsNullOrEmpty(cursor))
            {
                requestUri = $"{baseUrl}{cursor}";
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
