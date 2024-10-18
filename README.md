# Sidio.RevenueCat
An unofficial .NET SDK for the RevenueCat API and webhooks. This library is not affiliated with RevenueCat.

[![build](https://github.com/marthijn/Sidio.RevenueCat/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.RevenueCat/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.RevenueCat)](https://www.nuget.org/packages/Sidio.RevenueCat/)

# Installation
Add [the package](https://www.nuget.org/packages/Sidio.RevenueCat/) to your project.

# Project status
This package is currently in preview and is not yet feature complete.

# Usage
## Webhooks
* Capture the raw JSON and use the `IRevenueCatWebhookService` to parse the webhook data:
```csharp
private readonly IRevenueCatWebhookService _webhookService = new RevenueCatWebhookService();

var parseResult = _webhookService.TryParseSubscriptionEvent(rawJson, out var subscriptionEvent);
```