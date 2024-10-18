using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Api.V1.Responses;

public sealed class Entitlement
{
    [JsonPropertyName("expires_date")]
    public DateTime? ExpiresDate { get; set; }

    [JsonPropertyName("product_identifier")]
    public required string ProductIdentifier { get; set; }

    [JsonPropertyName("purchase_date")]
    public DateTime PurchaseDate { get; set; }

    public bool HasExpired()
    {
        if (ExpiresDate == null)
        {
            return false;
        }

        return DateTime.UtcNow > ExpiresDate.Value;
    }
}