# Bet.Extensions.Walmart

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Walmart/master/LICENSE)
![Master CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Walmart.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Walmart)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Walmart)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-walmart/shield/Bet.Extensions.Walmart/latest)](https://f.feedz.io/kdcllc/bet-extensions-walmart/packages/Bet.Extensions.Walmart/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

*Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions-walmart/nuget/index.json).*

## Summary

Walmart Seller DotNetCore library. The main goal was to design a library that supports the latest functionality for `HttpClient` and `System.Text.Json`


- [`Bet.Extensions.Walmart`](./src/Bet.Extensions.Walmart/)

## Hire me

Please send [email](mailto:kingdavidconsulting@gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.Extensions.Walmart
```

## Implemented

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
- [ ] [All released orders](https://developer.walmart.com/api/us/mp/orders#operation/getAllReleasedOrders)
- [ ] [An order](https://developer.walmart.com/api/us/mp/orders#operation/getAnOrder)
- [ ] [Acknowledge Orders](https://developer.walmart.com/api/us/mp/orders#operation/acknowledgeOrders)
- [ ] [Cancel Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/cancelOrderLines)
- [ ] [Refund Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/refundOrderLines)
- [ ] [Ship Order Lines](https://developer.walmart.com/api/us/mp/orders#operation/shippingUpdates)