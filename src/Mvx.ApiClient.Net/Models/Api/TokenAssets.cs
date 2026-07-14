#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TokenAssets response returned by the MultiversX API.</summary>
public sealed class TokenAssets
{
    /// <summary>Gets the upstream <c>website</c> value.</summary>
    [JsonPropertyName("website")]
    public string? Website { get; init; }

    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public TokenAssetsStatus? Status { get; init; }

    /// <summary>Gets the upstream <c>pngUrl</c> value.</summary>
    [JsonPropertyName("pngUrl")]
    public string? PngUrl { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>svgUrl</c> value.</summary>
    [JsonPropertyName("svgUrl")]
    public string? SvgUrl { get; init; }

    /// <summary>Gets the upstream <c>ledgerSignature</c> value.</summary>
    [JsonPropertyName("ledgerSignature")]
    public string? LedgerSignature { get; init; }

    /// <summary>Gets the upstream <c>lockedAccounts</c> value.</summary>
    [JsonPropertyName("lockedAccounts")]
    public JsonElement? LockedAccounts { get; init; }

    /// <summary>Gets the upstream <c>extraTokens</c> value.</summary>
    [JsonPropertyName("extraTokens")]
    public IReadOnlyList<string>? ExtraTokens { get; init; }

    /// <summary>Gets the upstream <c>preferredRankAlgorithm</c> value.</summary>
    [JsonPropertyName("preferredRankAlgorithm")]
    public TokenAssetsPreferredRankAlgorithm? PreferredRankAlgorithm { get; init; }

    /// <summary>Gets the upstream <c>priceSource</c> value.</summary>
    [JsonPropertyName("priceSource")]
    public TokenAssetsPriceSource? PriceSource { get; init; }

}
