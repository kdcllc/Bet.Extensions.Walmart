# Bet.AspNetCore.Walmart

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Walmart/master/LICENSE)
![Master CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.AspNetCore.Walmart.svg)](https://www.nuget.org/packages?q=Bet.AspNetCore.Walmart)
![Nuget](https://img.shields.io/nuget/dt/Bet.AspNetCore.Walmart)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-walmart/shield/Bet.AspNetCore.Walmart/latest)](https://f.feedz.io/kdcllc/bet-extensions-walmart/packages/Bet.AspNetCore.Walmart/latest/download)

## Summary

The purpose of this repo is to have a Walmart Webhook Event Api middleware to register and utilize.

It provides with Basic Authorization.

## Hire me

Please send [email](mailto:kingdavidconsulting[AT]gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.AspNetCore.Walmart
```

## Usage

1. Register Services

```csharp
    builder.Services.AddWalmartWebhooksEvents((o, c) =>
    {
        o.UserName = "username";
        o.Password = "password";
    })
    .AddWebhookEvent<POCreatedEventHandler, POCreatedEvent>(WebhookEvents.POCreated);
```

2. Use Middleware

```csharp
    app.UseWalmartWebhookEvents();
```

3. The handler for this event.

```csharp
public class POCreatedEventHandler : IWebhookEventHandler<POCreatedEvent>
{
    private readonly ILogger<POCreatedEventHandler> _logger;

    public POCreatedEventHandler(ILogger<POCreatedEventHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<WebhookEventResult> HandleEventAsync(
        POCreatedEvent @event,
        string eventName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var json = JsonSerializer.Serialize(@event, DefaultJsonSerializer.Options);

            _logger.LogInformation(json);
            return Task.FromResult(new WebhookEventResult());
        }
        catch (Exception ex)
        {
            return Task.FromResult(new WebhookEventResult(ex));
        }
    }
}

```

Sandbox doesn't really allow for paging over the orders!
