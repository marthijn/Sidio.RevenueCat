using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V1.Responses;

public sealed class SubscriberResponse : ResponseBase
{
    [JsonPropertyName("subscriber")]
    public required Subscriber Subscriber { get; set; }
}