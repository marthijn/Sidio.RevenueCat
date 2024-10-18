using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sidio.RevenueCat.Webhooks.Converters;

public sealed class SubscriberAttributesConverter : JsonConverter<Dictionary<string, SubscriberAttribute>>
{
    public override Dictionary<string, SubscriberAttribute>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var subscriberAttributesDictionary = new Dictionary<string, SubscriberAttribute>();

        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        foreach (var emailProperty in root.EnumerateObject())
        {
            if (emailProperty.Value.TryGetProperty("updated_at_ms", out var updatedAtProperty) &&
                emailProperty.Value.TryGetProperty("value", out var valueProperty))
            {
                var email = emailProperty.Name;
                var subscriberAttributes = new SubscriberAttribute
                                               {
                                                   UpdatedAtMs = updatedAtProperty.GetInt64(),
                                                   Value = valueProperty.GetString() ?? string.Empty,
                                               };

                subscriberAttributesDictionary[email] = subscriberAttributes;
            }
        }

        return subscriberAttributesDictionary;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, SubscriberAttribute> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}