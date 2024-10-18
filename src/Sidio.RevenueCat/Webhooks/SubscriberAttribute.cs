using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

public sealed class SubscriberAttribute
{
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    [JsonPropertyName("updated_at_ms")]
    public long UpdatedAtMs { get; set; }
}