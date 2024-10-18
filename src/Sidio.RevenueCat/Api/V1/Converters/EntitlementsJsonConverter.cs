using System.Text.Json;
using System.Text.Json.Serialization;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Api.V1.Converters;

public sealed class EntitlementsJsonConverter : JsonConverter<Dictionary<string, Entitlement>>
{
    public override Dictionary<string, Entitlement> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var entitlements = new Dictionary<string, Entitlement>();

        foreach (var property in root.EnumerateObject())
        {
            var key = property.Name;
            var entitlement = JsonSerializer.Deserialize<Entitlement>(property.Value.GetRawText(), options);
            if (entitlement != null)
            {
                entitlements.Add(key, entitlement);
            }
        }

        return entitlements;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, Entitlement> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var kvp in value)
        {
            writer.WritePropertyName(kvp.Key);
            JsonSerializer.Serialize(writer, kvp.Value, options);
        }

        writer.WriteEndObject();
    }
}