using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Enums;

public enum ErrorCode
{
    [JsonPropertyName("IPFS_ERROR")]
    IpfsError,
    
    [JsonPropertyName("NOT_FOUND")]
    NotFound,
    
    [JsonPropertyName("TIMEOUT")]
    Timeout,
    
    [JsonPropertyName("UNKNOWN_ERROR")]
    UnknownError,
    
    [JsonPropertyName("INVALID_CONTENT_TYPE")]
    InvalidContentType,
    
    [JsonPropertyName("JSON_PARSE_ERROR")]
    JsonParseError,
    
    [JsonPropertyName("EMPTY_METADATA")]
    EmptyMetadata
}
