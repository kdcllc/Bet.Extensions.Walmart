﻿using System.Net.Http.Json;

using Bet.Extensions.Walmart;
using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Extensions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Clients;
using Bet.Extensions.Walmart.Models;
using Bet.Extensions.Walmart.Models.Authentication;
using Bet.Extensions.Walmart.Models.Items;
using Bet.Extensions.Walmart.Models.Items.Queries;
using Bet.Extensions.Walmart.Models.Notifications;

using Microsoft.Extensions.Options;

public class Main : IMain
{
    private readonly ILogger<Main> _logger;
    private readonly WalmartOptions _options;
    private readonly IWalmartBaseClient _baseClient;
    private readonly IWalmartNotificationsClient _walmartNotificationsClient;
    private readonly IWalmartItemsClient _walmartItemsClient;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Main(
        IWalmartBaseClient baseClient,
        IWalmartNotificationsClient walmartNotificationsClient,
        IWalmartItemsClient walmartItemsClient,
        IOptions<WalmartOptions> options,
        IHostApplicationLifetime applicationLifetime,
        IConfiguration configuration,
        ILogger<Main> logger)
    {
        _options = options.Value;
        _baseClient = baseClient ?? throw new ArgumentNullException(nameof(baseClient));
        _walmartNotificationsClient = walmartNotificationsClient ?? throw new ArgumentNullException(nameof(walmartNotificationsClient));
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

        await TestingNotificationsAsync(cancellationToken);

        // await TestingItemsAsync(cancellationToken);
        // await ListAllItemsAsync(cancellationToken);
        // await TokenDetailsAsync(cancellationToken);

        return 0;
    }

    private async Task TestingNotificationsAsync(CancellationToken cancellationToken)
    {
        // 1. create
        var newEvents =
            new SubscriptionEvent
            {
                EventType = nameof(EventTypeEnum.OFFER_UNPUBLISHED),
                EventVersion = "V1",
                ResourceName = nameof(ResourceNameEnum.ITEM),
                EventUrl = "https://prod-09.eastus2.logic.azure.com:443/workflows/128cc6fed94d445f9ea9bf03c523aa8e/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=iMR9VlvNWlNYCRJRctFlxZoVQCknaQMJZyTc-NS6fZY",
                Status = nameof(StatusEnum.INACTIVE)
            };

        var createdSubscription = await _walmartNotificationsClient.CreateAsync(newEvents, cancellationToken);

        // 2. test
        // var testResult = await _walmartNotificationsClient.TestAsync(createdSubscription, cancellationToken);

        // 3. update
        var updateSubscription = new SubscriptionEvent
        {
            Status = nameof(StatusEnum.ACTIVE),
        };

        var updatedSubscription = await _walmartNotificationsClient.UpdateAsync(createdSubscription.SubscriptionId, updateSubscription, cancellationToken);

        // 4. delete
        var deletedResult = await _walmartNotificationsClient.DeleteAsync(updatedSubscription.SubscriptionId, cancellationToken);
        _logger.LogInformation("{deleteMessage}", deletedResult?.Message);

        var subscriptions = await _walmartNotificationsClient.ListAllAsync(cancellationToken);
        var eventTypes = await _walmartNotificationsClient.ListAllEventTypesAsync(cancellationToken);
    }

    /// <summary>
    /// Demostrates Walmart Api Items Client.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task TestingItemsAsync(CancellationToken cancellationToken)
    {
        var singelItem = await _walmartItemsClient.GetAsync("2AC949987B76454D", cancellationToken);
        var skus = new List<string>
        {
            "2AC949987B76454D"
        };

        var assosiation = await _walmartItemsClient.GetItemAssociationsAsync(skus, cancellationToken);

        var count = 0;
        await foreach (var item in _walmartItemsClient.ListAllAsync(new ItemQuery { Limit = "200" }, cancellationToken)
                                                      .WithCancellation(cancellationToken))
        {
            _logger.LogInformation(item.ProductName);
            count++;
        }

        _logger.LogInformation(count.ToString());
    }

    /// <summary>
    /// Demostrates how to interact with Walmart Api Items directly.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task ListAllItemsAsync(CancellationToken cancellationToken)
    {
        var cursor = string.Empty;

        var query = new ItemQuery
        {
            NextCursor = "*"
        };

        do
        {
            var requestUri = $"/{_options.Version}/items/";

            var parameters = query.ToKeyValuePair();
            var url = parameters.CompileRequestUri(requestUri);

            var response = await _baseClient.HttpClient.GetFromJsonAsync<ItemList>(url, cancellationToken);
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

    /// <summary>
    /// Demostrates how to interact with Walmart Authetnication Api directly.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
