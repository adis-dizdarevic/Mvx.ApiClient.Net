using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Enums;

public enum SortDirection
{
    [JsonPropertyName("asc")]
    Ascending,
    
    [JsonPropertyName("desc")]
    Descending
}
