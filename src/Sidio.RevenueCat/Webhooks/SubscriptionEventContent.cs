using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks;

public sealed class SubscriptionEventContent : CommonSubscriptionEventContent
{
    [JsonPropertyName("product_id")]
    public required string ProductId { get; set; }

    [JsonPropertyName("entitlement_ids")]
    public string[]? EntitlementIds { get; set; }

    [JsonPropertyName("period_type")]
    public required string PeriodType { get; set; }

    [JsonPropertyName("purchased_at_ms")]
    public long PurchasedAtMs { get; set; }

    [JsonPropertyName("grace_period_expiration_at_ms")]
    public long? GracePeriodExpirationAtMs { get; set; }

    [JsonPropertyName("expiration_at_ms")]
    public long? ExpirationAtMs { get; set; }

    [JsonPropertyName("auto_resume_at_ms")]
    public long? AutoResumeAtMs { get; set; }

    [JsonPropertyName("store")]
    public required string Store { get; set; }

    [JsonPropertyName("is_trial_conversion")]
    public bool? IsTrialConversion { get; set; }

    [JsonPropertyName("cancel_reason")]
    public string? CancelReason { get; set; }

    [JsonPropertyName("expiration_reason")]
    public string? ExpirationReason { get; set; }

    [JsonPropertyName("new_product_id")]
    public string? NewProductId { get; set; }

    [JsonPropertyName("presented_offering_id")]
    public string? PresentedOfferingId { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("price_in_purchased_currency")]
    public double? PriceInPurchasedCurrency { get; set; }

    [JsonPropertyName("tax_percentage")]
    public double? TaxPercentage { get; set; }

    [JsonPropertyName("commission_percentage")]
    public double? CommissionPercentage { get; set; }

    [JsonPropertyName("subscriber_attributes")]
    public Dictionary<string, SubscriberAttribute> SubscriberAttributes { get; set; } = new ();

    [JsonPropertyName("transaction_id")]
    public required string TransactionId { get; set; }

    [JsonPropertyName("original_transaction_id")]
    public required string OriginalTransactionId { get; set; }

    [JsonPropertyName("is_family_share")]
    public bool IsFamilyShare { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("offer_code")]
    public string? OfferCode { get; set; }
}