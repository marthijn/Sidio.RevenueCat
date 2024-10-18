using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class ProjectResponse : IdResponse
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}