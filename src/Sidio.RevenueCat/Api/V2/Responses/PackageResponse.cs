using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class PackageResponse : IdResponse
{
    [JsonPropertyName("lookup_key")]
    public required string LookupKey { get; set; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("position")]
    public required int Position { get; set; }

    [JsonPropertyName("products")]
    public PagedResponse<ProductResponse>? Products { get; set; }
}