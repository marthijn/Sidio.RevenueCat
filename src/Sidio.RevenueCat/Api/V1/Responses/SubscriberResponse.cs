using Sidio.RevenueCat.Api.V1.Responses;

namespace Essentia.Web.RevenueCat.Api.V1.Responses;

using System.Text.Json.Serialization;

public sealed class SubscriberResponse : ResponseBase
{
    [JsonPropertyName("subscriber")]
    public required Subscriber Subscriber { get; set; }
}