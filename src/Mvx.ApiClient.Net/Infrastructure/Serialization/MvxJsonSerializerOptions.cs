using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure.Serialization;

internal static class MvxJsonSerializerOptions
{
    public static JsonSerializerOptions Default { get; } = Create();

    private static JsonSerializerOptions Create()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
        };
        options.Converters.Add(new BigIntegerJsonConverter());
        options.Converters.Add(new SafeEnumJsonConverterFactory());

        return options;
    }
}
