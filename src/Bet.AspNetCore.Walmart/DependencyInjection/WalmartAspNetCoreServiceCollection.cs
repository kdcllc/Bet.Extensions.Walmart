using Bet.AspNetCore.Walmart.WebhookEvents;
using Bet.AspNetCore.Walmart.WebhookEvents.Internal;
using Bet.Extensions.Walmart.Services;
using Bet.Extensions.Walmart.Services.Impl;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class WalmartAspNetCoreServiceCollection
{
    public static IWebhookEventBuilder AddWalmartWebhooksEvents(this IServiceCollection services)
    {
        return AddWalmartWebhooksEvents(services, (o, c) => { });
    }

    /// <summary>
    /// Add Walmart Webhooks Events.
    /// </summary>
    /// <param name="services">The DI services.</param>
    /// <param name="configure">The configuration for the webhooks events.</param>
    /// <returns></returns>
    public static IWebhookEventBuilder AddWalmartWebhooksEvents(
        this IServiceCollection services,
        Action<WebhookEventOptions, IConfiguration> configure)
    {
        var builder = new WebhookEventBuilder(services);

        builder.Services.TryAddTransient(typeof(IWebhookSerializer<>), typeof(WebhookSerializer<>));

        builder.Services.AddOptions<WebhookEventOptions>(nameof(WebhookEventOptions))
            .Configure<IConfiguration>((options, configuration) =>
            {
                var o = new WebhookEventOptions();
                configure.Invoke(options, configuration);
            });

        return builder;
    }

    /// <summary>
    /// Use Walmart Webhook Events Middleware.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseWalmartWebhookEvents(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WebookEventMiddleware>();
    }
}
