using Bet.Extensions.Walmart.Abstractions;
using Bet.Extensions.Walmart.Abstractions.Options;
using Bet.Extensions.Walmart.Authorize;
using Bet.Extensions.Walmart.Clients;
using Bet.Extensions.Walmart.Clients.Impl;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Polly;
using Polly.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class WalmartServiceExtensions
{
    public static IServiceCollection AddWalmartClient(
        this IServiceCollection services,
        Action<WalmartOptions, IServiceProvider>? configOptions = null)
    {
        // configure shopify options
        services.AddChangeTokenOptions<WalmartOptions>(nameof(WalmartOptions), configureAction: (o, sp) => configOptions?.Invoke(o, sp));

        services.AddTransient<AuthorizeHandler>();

        services.AddHttpClient<IWalmartBaseClient, WalmartBaseClient>(nameof(WalmartOptions))
            .AddHttpMessageHandler<AuthorizeHandler>()
            .ConfigureHttpClient(
                (sp, client) =>
                {
                    var options = sp.GetRequiredService<IOptions<WalmartOptions>>().Value;
                    client.Timeout = options.Timeout;
                    client.BaseAddress = options.BaseUrl;
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var authHeader = ($"{options.ClientId}:{options.ClientSecret}").ToBase64String();

                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {authHeader}");

                    client.DefaultRequestHeaders.Add(WalmartHeaders.ServiceName, nameof(WalmartBaseClient));
                })
            .AddPolicyHandler(
                (sp, request) =>
                {
                    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                    var options = sp.GetRequiredService<IOptions<WalmartOptions>>().Value;
                    var logger = loggerFactory.CreateLogger(request?.RequestUri?.ToString() ?? nameof(WalmartBaseClient));

                    return Policy.Handle<HttpRequestException>()
                                         .OrTransientHttpStatusCode()
                                         .RetryAsync(options.Retry)
                                         .WithPolicyKey("WalmartTransientHttpPolicy");
                });

        services.AddTransient<IWalmartItemsClient, WalmartItemsClient>();
        services.AddTransient<IWalmartNotificationsClient, WalmartNotificationsClient>();
        services.AddTransient<IWalmartOrdersClient, WalmartOrdersClient>();

        return services;
    }
}
