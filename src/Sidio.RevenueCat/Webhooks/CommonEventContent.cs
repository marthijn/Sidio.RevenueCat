using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

public class CommonEventContent
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    [JsonPropertyName("environment")]
    public required string Environment { get; set; }

    public bool IsProduction => Environment.Equals("PRODUCTION", StringComparison.InvariantCultureIgnoreCase);
}