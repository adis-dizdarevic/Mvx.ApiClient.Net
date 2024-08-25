using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.HttpClientProviderLib;

public static class JsonSerializerConfig
{
    public static JsonSerializerOptions DefaultOptions { get; } = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
}
