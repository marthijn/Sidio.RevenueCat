using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class OfferingResponse : IdResponse
{
    [JsonPropertyName("lookup_key")]
    public required string LookupKey { get; set; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("is_current")]
    public required bool IsCurrent { get; set; }

    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> MetaData { get; set; } = new ();

    [JsonPropertyName("packages")]
    public PagedResponse<PackageResponse>? Packages { get; set; }
}