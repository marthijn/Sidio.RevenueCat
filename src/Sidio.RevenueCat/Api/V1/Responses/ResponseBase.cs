using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V1.Responses;

public abstract class ResponseBase
{
    [JsonPropertyName("request_date")]
    public DateTime RequestDate { get; set; }

    [JsonPropertyName("request_date_ms")]
    public long RequestDateInMs { get; set; }
}