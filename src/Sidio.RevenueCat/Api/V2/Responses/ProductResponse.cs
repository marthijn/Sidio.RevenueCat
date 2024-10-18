using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class ProductResponse : IdResponse
{
    [JsonPropertyName("store_identifier")]
    public required string StoreIdentifier { get; set; }

    [JsonPropertyName("app_id")]
    public required string AppId { get; set; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("subscription")]
    public SubscriptionResponse? Subscription { get; set; }

    [JsonPropertyName("app")]
    public AppResponse? App { get; set; }
}