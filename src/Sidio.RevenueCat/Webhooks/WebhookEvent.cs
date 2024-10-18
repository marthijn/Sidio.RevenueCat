using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

internal sealed class WebhookEvent
{
    [JsonPropertyName("api_version")]
    public required string ApiVersion { get; set; }

    [JsonPropertyName("event")]
    public required CommonEventContent Event { get; set; }
}