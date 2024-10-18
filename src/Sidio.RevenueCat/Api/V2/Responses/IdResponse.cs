using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public abstract class IdResponse : ObjectResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("created_at")]
    public int? CreatedAt { get; set; }
}