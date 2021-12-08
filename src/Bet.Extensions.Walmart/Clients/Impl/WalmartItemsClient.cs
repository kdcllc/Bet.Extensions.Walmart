using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Extensions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Failure;
using Bet.Extensions.Walmart.Models.Items;
using Bet.Extensions.Walmart.Models.Items.Queries;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Walmart.Clients.Impl;

internal class WalmartItemsClient : IWalmartItemsClient
{
    private readonly IWalmartBaseClient _client;
    private readonly ILogger<WalmartItemsClient> _logger;
    private readonly WalmartOptions _options;

    public WalmartItemsClient(
        IWalmartBaseClient client,
        IOptions<WalmartOptions> options,
        ILogger<WalmartItemsClient> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options.Value;
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<Item> ListAllAsync(ItemsQuery query, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor;
        do
        {
            var requestUri = $"/{_options.Version}/items/";

            var parameters = query.ToKeyValuePair();
            var url = parameters.CompileRequestUri(requestUri);

            var response = await _client.HttpClient.GetFromJsonAsync<ItemResponse>(url, cancellationToken);
            cursor = response?.NextCursor;

            if (cursor != null)
            {
                query.NextCursor = cursor;
            }

            if (response?.Items != null)
            {
                foreach (var item in response.Items)
                {
                    yield return item;
                }
            }
        }
        while (!string.IsNullOrEmpty(cursor));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Item>?> ListAsync(ItemsQuery query, CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/";

        var parameters = query.ToKeyValuePair();
        var url = parameters.CompileRequestUri(requestUri);

        var response = await _client.HttpClient.GetFromJsonAsync<ItemResponse>(url, cancellationToken);

        return response?.Items;
    }

    /// <inheritdoc/>
    public async Task<Item?> GetAsync(string id, ProductTypeEnum productType, CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/{id}";

        requestUri += $"?productIdType={productType}";

        var response = await _client.HttpClient.GetFromJsonAsync<ItemResponse>(requestUri, cancellationToken);

        return response?.Items?.FirstOrDefault();
    }

    /// <inheritdoc/>
    public async Task<Item?> GetAsync(string id, CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/{id}";

        var response = await _client.HttpClient.GetFromJsonAsync<ItemResponse>(requestUri, cancellationToken);

        return response?.Items?.FirstOrDefault();
    }

    /// <inheritdoc/>
    public async Task<Taxonomy?> GetTaxonomyAsync(CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/taxonomy/";
        var response = await _client.HttpClient.GetFromJsonAsync<Taxonomy>(requestUri, cancellationToken);
        return response;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(string sku, CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/{sku}";

        await _client.HttpClient.DeleteAsync(requestUri, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ItemAssociations>?> GetItemAssociationsAsync(IList<string> skus, CancellationToken cancellationToken)
    {
        var requestUri = $"/{_options.Version}/items/associations";

        var list = new List<ItemAssociations>();

        foreach (var sku in skus)
        {
            list.Add(new ItemAssociations { Sku = sku });
        }

        var requestData = new ItemAssociationsResponse
        {
            Items = list.ToArray()
        };

        var response = await _client.HttpClient.PostAsJsonAsync<ItemAssociationsResponse>(
            requestUri,
            requestData,
            DefaultJsonSerializer.Options,
            cancellationToken);
        var content = await response.Content.ReadAsStreamAsync(cancellationToken);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            var error = await JsonSerializer.DeserializeAsync<ErrorResponse>(content, DefaultJsonSerializer.Options, cancellationToken);

            _logger.LogError(ex, error?.Errors?[0]?.Description);
            return null;
        }



        var result = await JsonSerializer.DeserializeAsync<ItemAssociationsResponse>(content, DefaultJsonSerializer.Options, cancellationToken);

        return result?.Items;
    }
}
