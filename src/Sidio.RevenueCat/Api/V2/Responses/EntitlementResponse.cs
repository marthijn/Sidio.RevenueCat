using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class EntitlementResponse : IdResponse
{
    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

    [JsonPropertyName("lookup_key")]
    public required string LookupKey { get; set; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("products")]
    public PagedResponse<ProductResponse>? Products { get; set; }
}