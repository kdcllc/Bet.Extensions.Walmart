using Bet.Extensions.Walmart.Models.Notifications.Webhook;
using Bet.Extensions.Walmart.Services;
using Bet.Extensions.Walmart.Services.Impl;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Bet.Extensions.Walmart.UnitTest;

public class WebhookServiceTests
{
    [Fact]
    public async Task WebhookFactory_Get_POCreatedEvent()
    {
        var services = new ServiceCollection();

        services.AddTransient(typeof(IWebhookSerializer<>), typeof(WebhookSerializer<>));

        var sp = services.BuildServiceProvider();

        var p = sp.GetRequiredService<IWebhookSerializer<Event>>();
        Assert.NotNull(p);

        using var stream = File.OpenRead(Path.Combine("Data", $"{nameof(POCreatedEvent)}.json"));
        var model = await p.GetEventAsync(stream);
        stream.Position = 0;

        switch (model?.Source?.EventType)
        {
            case "PO_CREATED":
                var v = sp.GetRequiredService<IWebhookSerializer<POCreatedEvent>>();
                Assert.NotNull(v);

                var c = await v.GetEventAsync(stream);
                break;
        }
    }
}
