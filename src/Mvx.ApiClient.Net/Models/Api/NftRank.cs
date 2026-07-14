#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftRank response returned by the MultiversX API.</summary>
public sealed class NftRank
{
    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>rank</c> value.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; init; }

}
