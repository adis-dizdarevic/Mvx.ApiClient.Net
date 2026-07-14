#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftRarities response returned by the MultiversX API.</summary>
public sealed class NftRarities
{
    /// <summary>Gets the upstream <c>statistical</c> value.</summary>
    [JsonPropertyName("statistical")]
    public NftRarity? Statistical { get; init; }

    /// <summary>Gets the upstream <c>trait</c> value.</summary>
    [JsonPropertyName("trait")]
    public NftRarity? Trait { get; init; }

    /// <summary>Gets the upstream <c>jaccardDistances</c> value.</summary>
    [JsonPropertyName("jaccardDistances")]
    public NftRarity? JaccardDistances { get; init; }

    /// <summary>Gets the upstream <c>openRarity</c> value.</summary>
    [JsonPropertyName("openRarity")]
    public NftRarity? OpenRarity { get; init; }

    /// <summary>Gets the upstream <c>custom</c> value.</summary>
    [JsonPropertyName("custom")]
    public NftRarity? Custom { get; init; }

}
