using System.Net.Http.Json;

using Bet.Extensions.Walmart;
using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Extensions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Clients;
using Bet.Extensions.Walmart.Models.Authentication;
using Bet.Extensions.Walmart.Models.Items;
using Bet.Extensions.Walmart.Models.Items.Queries;

using Microsoft.Extensions.Options;

public class Main : IMain
{
    private readonly ILogger<Main> _logger;
    private readonly WalmartOptions _options;
    private readonly IWalmartBaseClient _baseClient;
    private readonly IWalmartItemsClient _walmartItemsClient;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Main(
        IWalmartBaseClient baseClient,
        IWalmartItemsClient walmartItemsClient,
        IOptions<WalmartOptions> options,
        IHostApplicationLifetime applicationLifetime,
        IConfiguration configuration,
        ILogger<Main> logger)
    {
        _options = options.Value;
        _baseClient = baseClient ?? throw new ArgumentNullException(nameof(baseClient));
        _walmartItemsClient = walmartItemsClient ?? throw new ArgumentNullException(nameof(walmartItemsClient));
        _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IConfiguration Configuration { get; set; }

    public async Task<int> RunAsync()
    {
        _logger.LogInformation("Main executed");

        // use this token for stopping the services
        var cancellationToken = _applicationLifetime.ApplicationStopping;

        var singelItem = await _walmartItemsClient.GetAsync("2AC949987B76454D", cancellationToken);
        var skus = new List<string>
        {
            "2AC949987B76454D"
        };

        var assosiation = await _walmartItemsClient.GetItemAssociationsAsync(skus, cancellationToken);

        var count = 0;
        await foreach (var item in _walmartItemsClient.ListAllAsync(new ItemsQuery { Limit = "200" }, cancellationToken)
                                                      .WithCancellation(cancellationToken))
        {
            _logger.LogInformation(item.ProductName);
            count++;
        }

        _logger.LogInformation(count.ToString());

        // await ListAllItemsAsync(cancellationToken);
        // await TokenDetailsAsync(cancellationToken);

        return 0;
    }

    private async Task ListAllItemsAsync(CancellationToken cancellationToken)
    {
        var cursor = string.Empty;

        var query = new ItemsQuery
        {
            NextCursor = "*"
        };

        do
        {
            var requestUri = $"/{_options.Version}/items/";

            var parameters = query.ToKeyValuePair();
            var url = parameters.CompileRequestUri(requestUri);

            var response = await _baseClient.HttpClient.GetFromJsonAsync<ItemResponse>(url, cancellationToken);
            cursor = response?.NextCursor;
            query.NextCursor = cursor;
            if (response.Items != null)
            {
                foreach (var item in response.Items)
                {
                    _logger.LogInformation(item.Sku);
                }
            }
        }
        while (!string.IsNullOrEmpty(cursor));
    }

    private async Task TokenDetailsAsync(CancellationToken cancellationToken)
    {
        var tasks = new List<Task<AuthDetails>>();

        for (var i = 0; i < 300; i++)
        {
            var response = _baseClient.HttpClient.GetFromJsonAsync<AuthDetails>($"/{_options.Version}/token/detail", cancellationToken);
            tasks.Add(response);
        }

        var r = await Task.WhenAll(tasks);

        foreach (var item in r)
        {
            _logger.LogInformation(item.ExpireAt);
        }
    }
}
