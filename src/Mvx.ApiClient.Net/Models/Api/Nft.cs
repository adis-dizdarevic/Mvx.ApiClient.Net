#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Nft response returned by the MultiversX API.</summary>
public sealed class Nft
{
    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>collection</c> value.</summary>
    [JsonPropertyName("collection")]
    public string? Collection { get; init; }

    /// <summary>Gets the upstream <c>hash</c> value.</summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>attributes</c> value.</summary>
    [JsonPropertyName("attributes")]
    public string? Attributes { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public NftType? Type { get; init; }

    /// <summary>Gets the upstream <c>subType</c> value.</summary>
    [JsonPropertyName("subType")]
    public NftSubType? SubType { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>creator</c> value.</summary>
    [JsonPropertyName("creator")]
    public string? Creator { get; init; }

    /// <summary>Gets the upstream <c>royalties</c> value.</summary>
    [JsonPropertyName("royalties")]
    public decimal? Royalties { get; init; }

    /// <summary>Gets the upstream <c>uris</c> value.</summary>
    [JsonPropertyName("uris")]
    public IReadOnlyList<string>? Uris { get; init; }

    /// <summary>Gets the upstream <c>url</c> value.</summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>Gets the upstream <c>media</c> value.</summary>
    [JsonPropertyName("media")]
    public IReadOnlyList<NftMedia>? Media { get; init; }

    /// <summary>Gets the upstream <c>isWhitelistedStorage</c> value.</summary>
    [JsonPropertyName("isWhitelistedStorage")]
    public bool? IsWhitelistedStorage { get; init; }

    /// <summary>Gets the upstream <c>thumbnailUrl</c> value.</summary>
    [JsonPropertyName("thumbnailUrl")]
    public string? ThumbnailUrl { get; init; }

    /// <summary>Gets the upstream <c>tags</c> value.</summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }

    /// <summary>Gets the upstream <c>metadata</c> value.</summary>
    [JsonPropertyName("metadata")]
    public NftMetadata? Metadata { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>supply</c> value.</summary>
    [JsonPropertyName("supply")]
    public BigInteger? Supply { get; init; }

    /// <summary>Gets the upstream <c>decimals</c> value.</summary>
    [JsonPropertyName("decimals")]
    public long? Decimals { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public TokenAssets? Assets { get; init; }

    /// <summary>Gets the upstream <c>ticker</c> value.</summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>Gets the upstream <c>scamInfo</c> value.</summary>
    [JsonPropertyName("scamInfo")]
    public ScamInfo? ScamInfo { get; init; }

    /// <summary>Gets the upstream <c>score</c> value.</summary>
    [JsonPropertyName("score")]
    public decimal? Score { get; init; }

    /// <summary>Gets the upstream <c>rank</c> value.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; init; }

    /// <summary>Gets the upstream <c>rarities</c> value.</summary>
    [JsonPropertyName("rarities")]
    public NftRarities? Rarities { get; init; }

    /// <summary>Gets the upstream <c>isNsfw</c> value.</summary>
    [JsonPropertyName("isNsfw")]
    public bool? IsNsfw { get; init; }

    /// <summary>Gets the upstream <c>unlockSchedule</c> value.</summary>
    [JsonPropertyName("unlockSchedule")]
    public IReadOnlyList<UnlockMilestone>? UnlockSchedule { get; init; }

    /// <summary>Gets the upstream <c>unlockEpoch</c> value.</summary>
    [JsonPropertyName("unlockEpoch")]
    public long? UnlockEpoch { get; init; }

}
