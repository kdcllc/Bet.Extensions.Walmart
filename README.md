# Bet.Extensions.Walmart

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Walmart/master/LICENSE)
![Master CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Walmart.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Walmart)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Walmart)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-walmart/shield/Bet.Extensions.Walmart/latest)](https://f.feedz.io/kdcllc/bet-extensions-walmart/packages/Bet.Extensions.Walmart/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions-walmart/nuget/index.json)._

## Summary

Walmart Seller DotNetCore library. The main goal was to design a library that supports the latest functionality for `HttpClient` for http communication and `System.Text.Json` for serialization and de-serialization for https://seller.walmart.com/order-management/details.

- [`Bet.Extensions.Walmart.Abstractions`](./src/Bet.Extensions.Walmart.Abstractions/) - contains abstractions.
- [`Bet.Extensions.Walmart.Models`](./src/Bet.Extensions.Walmart.Models/) - contains v3 models.
- [`Bet.Extensions.Walmart`](./src/Bet.Extensions.Walmart/) - contains code to communicate with Walmart Seller Api v3.
- [`Bet.AspNetCore.Walmart`](./src/Bet.AspNetCore.Walmart/) - contains a webhook/ notification framework.
- [`Bet.Extensions.Walmart.Worker`](./src/Bet.Extensions.Walmart.Worker/) - a sample console application.
- [`WalmartWeb`](./src/WalmartWeb/) - a sample web api application.

## Hire me

Please send [email](mailto:kingdavidconsulting@gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.Extensions.Walmart
```

## Implemented Endpoints

### [Authentication & Authorization Management](https://developer.walmart.com/api/us/mp/auth)

- [x] [Token Detail](https://developer.walmart.com/api/us/mp/auth#operation/getTokenDetail)
- [x] [Token API](https://developer.walmart.com/api/us/mp/auth#operation/tokenAPI)

## [Item Management](https://developer.walmart.com/api/us/mp/items)

- [x] [Retire an item](https://developer.walmart.com/api/us/mp/items#operation/retireAnItem)
- [x] [Get Item Associations](https://developer.walmart.com/api/us/mp/items#operation/getItemAssociations)
- [x] [Taxonomy](https://developer.walmart.com/api/us/mp/items#operation/getTaxonomyResponse)
- [ ] [Get items count by status](https://developer.walmart.com/api/us/mp/items#operation/getCountByStatus)
- [ ] [Item Search](https://developer.walmart.com/api/us/mp/items#operation/getSearchResult)
- [x] [All items](https://developer.walmart.com/api/us/mp/items#operation/getAllItems)
- [x] [An item](https://developer.walmart.com/api/us/mp/items#operation/getAnItem)
- [ ] [Catalog Search](https://developer.walmart.com/api/us/mp/items#operation/getCatalogSearch)
- [ ] [Bulk Item Setup (Multiple)](https://developer.walmart.com/api/us/mp/items#operation/itemBulkUploads)

## [Notifications Management](https://developer.walmart.com/api/us/mp/notifications)

- [x] [All subscriptions](https://developer.walmart.com/api/us/mp/notifications#operation/getAllSubscriptions)
- [x] [Create subscription](https://developer.walmart.com/api/us/mp/notifications#operation/createSubscription)
- [x] [Delete Subscription](https://developer.walmart.com/api/us/mp/notifications#operation/deleteSubscription)
- [x] [Update Subscription](https://developer.walmart.com/api/us/mp/notifications#operation/updateSubscription)
- [x] [Test Notification](https://developer.walmart.com/api/us/mp/notifications#operation/testNotification)
- [x] [Event Types](https://developer.walmart.com/api/us/mp/notifications#operation/getEventTypes)

## [Orders](https://developer.walmart.com/api/us/mp/orders#tag/Orders)

- [x] [All orders](https://developer.walmart.com/api/us/mp/orders#operation/getAllOrders)
- [x] [All released orders](https://developer.walmart.com/api/us/mp/orders#operation/getAllReleasedOrders)
- [x] [An order](https://developer.walmart.com/api/us/mp/orders#operation/getAnOrder)
- [x] [Acknowledge Orders](https://developer.walmart.com/api/us/mp/orders#operation/acknowledgeOrders)
- [x] [Cancel Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/cancelOrderLines)
- [x] [Refund Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/refundOrderLines)
- [x] [Ship Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/shippingUpdates)
