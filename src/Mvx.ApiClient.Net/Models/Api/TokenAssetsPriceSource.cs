#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TokenAssetsPriceSource response returned by the MultiversX API.</summary>
public sealed class TokenAssetsPriceSource
{
    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public TokenAssetsPriceSourceType? Type { get; init; }

    /// <summary>Gets the upstream <c>url</c> value.</summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>Gets the upstream <c>path</c> value.</summary>
    [JsonPropertyName("path")]
    public string? Path { get; init; }

}
