using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

public class CommonSubscriptionEventContent : CommonEventContent
{
    [JsonPropertyName("event_timestamp_ms")]
    public required long Timestamp { get; set; }

    [JsonPropertyName("app_user_id")]
    public required string AppUserId { get; set; }

    [JsonPropertyName("original_app_user_id")]
    public required string OriginalAppUserId { get; set; }

    [JsonPropertyName("aliases")]
    public required string[] Aliases { get; set; }
}
