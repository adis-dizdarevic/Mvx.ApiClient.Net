#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TokenWithBalance response returned by the MultiversX API.</summary>
public sealed class TokenWithBalance
{
    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public TokenWithBalanceType? Type { get; init; }

    /// <summary>Gets the upstream <c>subType</c> value.</summary>
    [JsonPropertyName("subType")]
    public TokenWithBalanceSubType? SubType { get; init; }

    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>collection</c> value.</summary>
    [JsonPropertyName("collection")]
    public string? Collection { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>ticker</c> value.</summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>minted</c> value.</summary>
    [JsonPropertyName("minted")]
    public BigInteger? Minted { get; init; }

    /// <summary>Gets the upstream <c>burnt</c> value.</summary>
    [JsonPropertyName("burnt")]
    public BigInteger? Burnt { get; init; }

    /// <summary>Gets the upstream <c>initialMinted</c> value.</summary>
    [JsonPropertyName("initialMinted")]
    public BigInteger? InitialMinted { get; init; }

    /// <summary>Gets the upstream <c>decimals</c> value.</summary>
    [JsonPropertyName("decimals")]
    public long? Decimals { get; init; }

    /// <summary>Gets the upstream <c>isPaused</c> value.</summary>
    [JsonPropertyName("isPaused")]
    public bool? IsPaused { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public TokenAssets? Assets { get; init; }

    /// <summary>Gets the upstream <c>transactions</c> value.</summary>
    [JsonPropertyName("transactions")]
    public long? Transactions { get; init; }

    /// <summary>Gets the upstream <c>transactionsLastUpdatedAt</c> value.</summary>
    [JsonPropertyName("transactionsLastUpdatedAt")]
    public long? TransactionsLastUpdatedAt { get; init; }

    /// <summary>Gets the upstream <c>transfers</c> value.</summary>
    [JsonPropertyName("transfers")]
    public long? Transfers { get; init; }

    /// <summary>Gets the upstream <c>transfersLastUpdatedAt</c> value.</summary>
    [JsonPropertyName("transfersLastUpdatedAt")]
    public long? TransfersLastUpdatedAt { get; init; }

    /// <summary>Gets the upstream <c>accounts</c> value.</summary>
    [JsonPropertyName("accounts")]
    public long? Accounts { get; init; }

    /// <summary>Gets the upstream <c>accountsLastUpdatedAt</c> value.</summary>
    [JsonPropertyName("accountsLastUpdatedAt")]
    public long? AccountsLastUpdatedAt { get; init; }

    /// <summary>Gets the upstream <c>canUpgrade</c> value.</summary>
    [JsonPropertyName("canUpgrade")]
    public bool? CanUpgrade { get; init; }

    /// <summary>Gets the upstream <c>canMint</c> value.</summary>
    [JsonPropertyName("canMint")]
    public bool? CanMint { get; init; }

    /// <summary>Gets the upstream <c>canBurn</c> value.</summary>
    [JsonPropertyName("canBurn")]
    public bool? CanBurn { get; init; }

    /// <summary>Gets the upstream <c>canChangeOwner</c> value.</summary>
    [JsonPropertyName("canChangeOwner")]
    public bool? CanChangeOwner { get; init; }

    /// <summary>Gets the upstream <c>canAddSpecialRoles</c> value.</summary>
    [JsonPropertyName("canAddSpecialRoles")]
    public bool? CanAddSpecialRoles { get; init; }

    /// <summary>Gets the upstream <c>canPause</c> value.</summary>
    [JsonPropertyName("canPause")]
    public bool? CanPause { get; init; }

    /// <summary>Gets the upstream <c>canFreeze</c> value.</summary>
    [JsonPropertyName("canFreeze")]
    public bool? CanFreeze { get; init; }

    /// <summary>Gets the upstream <c>canWipe</c> value.</summary>
    [JsonPropertyName("canWipe")]
    public bool? CanWipe { get; init; }

    /// <summary>Gets the upstream <c>canTransferNftCreateRole</c> value.</summary>
    [JsonPropertyName("canTransferNftCreateRole")]
    public bool? CanTransferNftCreateRole { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>marketCap</c> value.</summary>
    [JsonPropertyName("marketCap")]
    public decimal? MarketCap { get; init; }

    /// <summary>Gets the upstream <c>supply</c> value.</summary>
    [JsonPropertyName("supply")]
    public BigInteger? Supply { get; init; }

    /// <summary>Gets the upstream <c>circulatingSupply</c> value.</summary>
    [JsonPropertyName("circulatingSupply")]
    public BigInteger? CirculatingSupply { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>mexPairType</c> value.</summary>
    [JsonPropertyName("mexPairType")]
    public TokenWithBalanceMexPairType? MexPairType { get; init; }

    /// <summary>Gets the upstream <c>totalLiquidity</c> value.</summary>
    [JsonPropertyName("totalLiquidity")]
    public decimal? TotalLiquidity { get; init; }

    /// <summary>Gets the upstream <c>totalVolume24h</c> value.</summary>
    [JsonPropertyName("totalVolume24h")]
    public decimal? TotalVolume24H { get; init; }

    /// <summary>Gets the upstream <c>isLowLiquidity</c> value.</summary>
    [JsonPropertyName("isLowLiquidity")]
    public bool? IsLowLiquidity { get; init; }

    /// <summary>Gets the upstream <c>lowLiquidityThresholdPercent</c> value.</summary>
    [JsonPropertyName("lowLiquidityThresholdPercent")]
    public decimal? LowLiquidityThresholdPercent { get; init; }

    /// <summary>Gets the upstream <c>tradesCount</c> value.</summary>
    [JsonPropertyName("tradesCount")]
    public long? TradesCount { get; init; }

    /// <summary>Gets the upstream <c>ownersHistory</c> value.</summary>
    [JsonPropertyName("ownersHistory")]
    public IReadOnlyList<TokenOwnerHistory>? OwnersHistory { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>valueUsd</c> value.</summary>
    [JsonPropertyName("valueUsd")]
    public decimal? ValueUsd { get; init; }

    /// <summary>Gets the upstream <c>attributes</c> value.</summary>
    [JsonPropertyName("attributes")]
    public string? Attributes { get; init; }

}
