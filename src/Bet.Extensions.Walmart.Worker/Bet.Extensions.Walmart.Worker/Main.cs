using System.Net.Http.Json;

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
using Bet.Extensions.Walmart.Models.Orders;
using Bet.Extensions.Walmart.Models.Orders.Queries;
using Bet.Extensions.Walmart.Models.Orders.Ship;

using Microsoft.Extensions.Options;

public class Main : IMain
{
    private readonly ILogger<Main> _logger;
    private readonly WalmartOptions _options;
    private readonly IWalmartBaseClient _baseClient;
    private readonly IWalmartOrdersClient _walmartOrdersClient;
    private readonly IWalmartNotificationsClient _walmartNotificationsClient;
    private readonly IWalmartItemsClient _walmartItemsClient;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Main(
        IWalmartBaseClient baseClient,
        IWalmartOrdersClient walmartOrdersClient,
        IWalmartNotificationsClient walmartNotificationsClient,
        IWalmartItemsClient walmartItemsClient,
        IOptions<WalmartOptions> options,
        IHostApplicationLifetime applicationLifetime,
        IConfiguration configuration,
        ILogger<Main> logger)
    {
        _options = options.Value;
        _baseClient = baseClient ?? throw new ArgumentNullException(nameof(baseClient));
        _walmartOrdersClient = walmartOrdersClient ?? throw new ArgumentNullException(nameof(walmartOrdersClient));
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

        await ListAllOrdersAsync(cancellationToken);

        // await ShipOrdersAsync(cancellationToken);

        // await TestingNotificationsAsync(cancellationToken);

        // await TestingItemsAsync(cancellationToken);
        // await ListAllItemsAsync(cancellationToken);
        // await TokenDetailsAsync(cancellationToken);
        return 0;
    }

    private async Task ListAllOrdersAsync(CancellationToken cancellationToken)
    {
        var count = 0;
        await foreach (var item in _walmartOrdersClient.ListAllReleasedAsync(new OrderQuery { ProductInfo = true, Limit = 2 }, cancellationToken)
                                              .WithCancellation(cancellationToken))
        {
            _logger.LogInformation(item.PurchaseOrderId);

            var order = await _walmartOrdersClient.GetAsync(new SingleOrderQuery { PurchaseOrderId = item.PurchaseOrderId, ProductInfo = true }, cancellationToken);

            count++;
        }

        _logger.LogInformation("{releaseOrdersCount}", count);

        count = 0;
        await foreach (var item in _walmartOrdersClient.ListAllAsync(new OrderQuery { Limit = 20, Status = "Created" }, cancellationToken)
                                              .WithCancellation(cancellationToken))
        {
            _logger.LogInformation(item.PurchaseOrderId);
            count++;
        }

        _logger.LogInformation("{createdOrdersCount}", count);
    }

    private async Task ShipOrdersAsync(CancellationToken cancellationToken)
    {
        var list = new List<(string po, string label)>
        {
            ("", ""),
        };

        foreach (var item in list)
        {
            await ShipOrderAsync(item.po, item.label, cancellationToken);
        }
    }

    private async Task ShipOrderAsync(string customerOrderId, string shipmentLabel, CancellationToken cancellationToken)
    {
        await foreach (var item in _walmartOrdersClient.ListAllAsync(new OrderQuery { Limit = 20, CustomerOrderId = customerOrderId }, cancellationToken)
                                      .WithCancellation(cancellationToken))
        {
            _logger.LogInformation("{purchaseOrderId} {customerOrderId} {lineCount}", item.PurchaseOrderId, item.CustomerOrderId, item.OrderLines.OrderLine.Count());

            var ackO = await _walmartOrdersClient.AcknowledgeAsync(item.PurchaseOrderId, cancellationToken);

            await Task.Delay(100);

            var lineNumbers = item.OrderLines.OrderLine.Count();

            var list = new List<OrderLine>();

            var ln = 1;

            for (var i = 0; i < lineNumbers; i++)
            {
                list.Add(new OrderLine
                {
                    LineNumber = ln.ToString(),
                    OrderLineStatuses = new OrdeLineStatusList
                    {
                        OrderLineStatus = new List<OrderLineStatus>
                        {
                            new OrderLineStatus
                            {
                                Status = nameof(OrderStatusEnum.Shipped),
                                StatusQuantity = StatusQuantity.Create(),
                                TrackingInfo = new TrackingInfo
                                {
                                    ShipDateTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                                    CarrierName = new CarrierName
                                    {
                                        Carrier = nameof(CarrierEnum.USPS)
                                    },
                                    MethodCode = nameof(OrderShipMethodEnum.Standard),
                                    TrackingNumber = shipmentLabel
                                }
                            }
                        }.ToArray(),
                    }
                });
                ln++;
            }

            var shipment = new OrderShipment
            {
                OrderLines = new OrderLineList() { OrderLine = list.ToArray() }
            };

            var shipO = await _walmartOrdersClient.ShipAsync(item.PurchaseOrderId, shipment, cancellationToken);

            _logger.LogInformation("Shipped: {purchaseOrderId} {trackingInfo} {name}", customerOrderId, shipmentLabel, item.ShippingInfo.PostalAddress.Name);
        }
    }

    private async Task TestingNotificationsAsync(CancellationToken cancellationToken)
    {
        // 1. create
        var newEvents =
            new SubscriptionEvent
            {
                EventType = nameof(EventTypeEnum.PO_LINE_AUTOCANCELLED),
                EventVersion = "V1",
                ResourceName = nameof(ResourceNameEnum.ORDER),
                EventUrl = Configuration["WebhooksUrl"],
                Status = nameof(StatusEnum.INACTIVE),
                Headers = new SubscriptionEventHeader
                {
                    ContentType = "application/json"
                }
            };

        var createdSubscription = await _walmartNotificationsClient.CreateAsync(newEvents, cancellationToken);

        // 2. update
        var updateSubscription = new SubscriptionEvent
        {
            Status = nameof(StatusEnum.ACTIVE),
        };

        var updatedSubscription = await _walmartNotificationsClient.UpdateAsync(createdSubscription.SubscriptionId, updateSubscription, cancellationToken);

        // 3. test not really needed upon creation of the event the sample data is send
        // var testResult = await _walmartNotificationsClient.TestAsync(updatedSubscription, cancellationToken);

        // 4. delete
        var deletedResult = await _walmartNotificationsClient.DeleteAsync(updatedSubscription.SubscriptionId, cancellationToken);
        _logger.LogInformation("{deleteMessage}", deletedResult?.Message);

        var subscriptions = await _walmartNotificationsClient.ListAllAsync(cancellationToken);

        foreach (var sub in subscriptions)
        {
            _logger.LogInformation("{id} - {type} - {url}", sub.SubscriptionId, sub.EventType, sub.EventUrl);
        }

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
