using System.Diagnostics.CodeAnalysis;

namespace Sidio.RevenueCat.Webhooks;

public interface IRevenueCatWebhookService
{
    bool IsTransferEvent(string json);

    bool TryParseSubscriptionEvent(string json, [NotNullWhen(true)] out SubscriptionEventContent? content);

    bool TryParseTransferEvent(string json, [NotNullWhen(true)] out TransferSubscriptionEventContent? content);
}