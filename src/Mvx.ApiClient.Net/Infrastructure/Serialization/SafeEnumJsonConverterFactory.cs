using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure.Serialization;

internal sealed class SafeEnumJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(SafeEnumJsonConverter<>).MakeGenericType(typeToConvert);

        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }

    private sealed class SafeEnumJsonConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct, Enum
    {
        private static readonly Dictionary<string, TEnum> ValuesByWireName = CreateValuesByWireName();
        private static readonly (bool HasValue, TEnum Value) Unknown = GetUnknownValue();

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Expected a string value for {typeof(TEnum).Name}.");
            }

            var value = reader.GetString();
            if (value is not null && ValuesByWireName.TryGetValue(value, out var parsedValue))
            {
                return parsedValue;
            }

            if (Unknown.HasValue)
            {
                return Unknown.Value;
            }

            throw new JsonException($"Unknown {typeof(TEnum).Name} value '{value}'.");
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var wireName = EnumWireName.GetValue(value);
            writer.WriteStringValue(wireName);
        }

        private static Dictionary<string, TEnum> CreateValuesByWireName()
        {
            var values = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);

            foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var enumValue = (TEnum)field.GetValue(null)!;
                values[field.Name] = enumValue;

                var wireName = field.GetCustomAttribute<EnumMemberAttribute>()?.Value;
                if (!string.IsNullOrWhiteSpace(wireName))
                {
                    values[wireName] = enumValue;
                }
            }

            return values;
        }

        private static (bool HasValue, TEnum Value) GetUnknownValue()
        {
            var hasValue = Enum.TryParse<TEnum>("Unknown", out var value);

            return (hasValue, value);
        }
    }
}
