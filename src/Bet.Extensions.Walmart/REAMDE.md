# Bet.Extensions.Walmart.Abstractions

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Walmart.Models/master/LIAbstractions
![Master CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.Extensions.Walmart/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Walmart.Models.svg)](https://www.nuget.org/packages?q=Bet.Extensions.WaAbstractionsMAbstractions
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Walmart.MAbstractions
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-walmart/shield/Bet.Extensions.Walmart.Models/latest)](https://f.feedz.io/kdcllc/bet-extensions-walmart/packages/Bet.Extensions.Walmart.Models/latest/dowAbstractions

## Summary

The purpose of this repo is to have a Walmart API Abstraction logic.

## Hire me

Please send [email](mailto:kingdavidconsulting[ A T ]gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.Extensions.Walmart.Abstractions
```


## Notes

- When testing with sandbox, the paging thru orders doesn't work
- At times after setting the acknowledged on order and then shipment label creation will cause:

```json
{
    "errors": {
        "error": [{
            "code": "INVALID_REQUEST_CONTENT.GMP_ORDER_API",
            "field": "data",
            "description": "INVALID_REQUEST_CONTENT :: Failed when called acknowledge API for '{actual__order_id}'.  Some or all qty in higher status",
            "info": "Request content is invalid.",
            "severity": "ERROR",
            "category": "DATA",
            "errorIdentifiers": {
                "entry": []
            }
        }]
    }
}
```
- x
