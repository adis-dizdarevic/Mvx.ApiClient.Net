using System.Buffers;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure.Serialization;

internal sealed class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => GetRawNumber(ref reader),
            _ => throw new JsonException("Expected a JSON string or number for a blockchain integer amount.")
        };

        if (BigInteger.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        throw new JsonException($"'{value}' is not a valid blockchain integer amount.");
    }

    public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }

    private static string GetRawNumber(ref Utf8JsonReader reader)
    {
        if (!reader.HasValueSequence)
        {
            return Encoding.UTF8.GetString(reader.ValueSpan);
        }

        return Encoding.UTF8.GetString(reader.ValueSequence.ToArray());
    }
}
