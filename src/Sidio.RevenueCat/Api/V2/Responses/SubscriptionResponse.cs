using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class SubscriptionResponse
{
    [JsonPropertyName("duration")]
    public required string Duration { get; set; }

    [JsonPropertyName("grace_period_duration")]
    public required string GracePeriodDuration { get; set; }

    [JsonPropertyName("trial_duration")]
    public required string TrialDuration { get; set; }
}