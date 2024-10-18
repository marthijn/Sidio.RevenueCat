using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public abstract class ObjectResponse
{
    [JsonPropertyName("object")]
    public string? Object { get; set; }
}