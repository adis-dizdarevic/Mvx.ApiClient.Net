#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftMetadataError response returned by the MultiversX API.</summary>
public sealed class NftMetadataError
{
    /// <summary>Gets the upstream <c>code</c> value.</summary>
    [JsonPropertyName("code")]
    public NftMetadataErrorCode? Code { get; init; }

    /// <summary>Gets the upstream <c>message</c> value.</summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

}
