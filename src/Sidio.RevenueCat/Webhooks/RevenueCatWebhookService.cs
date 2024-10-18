using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Sidio.RevenueCat.Webhooks.Converters;

namespace Sidio.RevenueCat.Webhooks;

public sealed class RevenueCatWebhookService : IRevenueCatWebhookService
{
    private readonly ILogger<RevenueCatWebhookService> _logger;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new ()
                                                                        {
                                                                            PropertyNameCaseInsensitive = true,
                                                                            Converters = { new SubscriberAttributesConverter() },
                                                                        };

    public RevenueCatWebhookService(ILogger<RevenueCatWebhookService> logger)
    {
        _logger = logger;
    }

    public bool IsTransferEvent(string json)
    {
        var parsed = JsonSerializer.Deserialize<WebhookEvent>(json, _jsonSerializerOptions);
        return parsed != null && parsed.Event.Type.Equals("TRANSFER", StringComparison.InvariantCultureIgnoreCase);
    }

    public bool TryParseSubscriptionEvent(string json, [NotNullWhen(true)] out SubscriptionEventContent? content)
    {
        try
        {
            var parsed = JsonSerializer.Deserialize<InternalWebhookEvent<SubscriptionEventContent>>(json, _jsonSerializerOptions);
            if (parsed is null)
            {
                content = null;
                return false;
            }

            content = parsed.Event;
            return true;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse subscription event");
        }

        content = null;
        return false;
    }

    public bool TryParseTransferEvent(string json, [NotNullWhen(true)] out TransferSubscriptionEventContent? content)
    {
        try
        {
            var parsed = JsonSerializer.Deserialize<InternalWebhookEvent<TransferSubscriptionEventContent>>(json, _jsonSerializerOptions);
            if (parsed is null)
            {
                content = null;
                return false;
            }

            content = parsed.Event;
            return true;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse transfer event");
        }

        content = null;
        return false;
    }

    private sealed class InternalWebhookEvent<T>
    {
        [JsonPropertyName("event")]
        public required T Event { get; set; }
    }
}