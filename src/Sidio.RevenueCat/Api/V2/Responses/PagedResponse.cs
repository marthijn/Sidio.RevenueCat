using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class PagedResponse<T> : ObjectResponse
    where T : class
{
    [JsonPropertyName("items")]
    public IEnumerable<T> Items { get; set; } = Array.Empty<T>();

    [JsonPropertyName("next_page")]
    public string? NextPage { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public bool HasMore => !string.IsNullOrWhiteSpace(NextPage);
}