using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class ErrorResponse
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("param")]
    public string? Param { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("retryable")]
    public bool Retryable { get; set; }

    [JsonPropertyName("doc_url")]
    public string? DocumentationUrl { get; set; }
}