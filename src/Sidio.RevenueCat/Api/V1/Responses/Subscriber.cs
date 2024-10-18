using System.Text.Json.Serialization;
using Sidio.RevenueCat.Api.V1.Converters;

namespace Sidio.RevenueCat.Api.V1.Responses;

public sealed class Subscriber
{
    [JsonPropertyName("original_app_user_id")]
    public required string OriginalAppUserId { get; set; }

    [JsonPropertyName("entitlements")]
    [JsonConverter(typeof(EntitlementsJsonConverter))]
    public Dictionary<string, Entitlement> Entitlements { get; set; } = new ();
}