#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftRarity response returned by the MultiversX API.</summary>
public sealed class NftRarity
{
    /// <summary>Gets the upstream <c>rank</c> value.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; init; }

    /// <summary>Gets the upstream <c>score</c> value.</summary>
    [JsonPropertyName("score")]
    public decimal? Score { get; init; }

}
