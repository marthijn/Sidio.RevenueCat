using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

public sealed class TransferSubscriptionEventContent : CommonEventContent
{
    [JsonPropertyName("store")]
    public required string Store { get; set; }

    [JsonPropertyName("transferred_from")]
    public required string[] TransferredFrom { get; set; }

    [JsonPropertyName("transferred_to")]
    public required string[] TransferredTo { get; set; }
}