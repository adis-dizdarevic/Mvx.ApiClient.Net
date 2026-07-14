#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the FeatureConfigs response returned by the MultiversX API.</summary>
public sealed class FeatureConfigs
{
    /// <summary>Gets the upstream <c>eventsNotifier</c> value.</summary>
    [JsonPropertyName("eventsNotifier")]
    public bool? EventsNotifier { get; init; }

    /// <summary>Gets the upstream <c>guestCaching</c> value.</summary>
    [JsonPropertyName("guestCaching")]
    public bool? GuestCaching { get; init; }

    /// <summary>Gets the upstream <c>transactionPool</c> value.</summary>
    [JsonPropertyName("transactionPool")]
    public bool? TransactionPool { get; init; }

    /// <summary>Gets the upstream <c>transactionPoolWarmer</c> value.</summary>
    [JsonPropertyName("transactionPoolWarmer")]
    public bool? TransactionPoolWarmer { get; init; }

    /// <summary>Gets the upstream <c>updateCollectionExtraDetails</c> value.</summary>
    [JsonPropertyName("updateCollectionExtraDetails")]
    public bool? UpdateCollectionExtraDetails { get; init; }

    /// <summary>Gets the upstream <c>updateAccountsExtraDetails</c> value.</summary>
    [JsonPropertyName("updateAccountsExtraDetails")]
    public bool? UpdateAccountsExtraDetails { get; init; }

    /// <summary>Gets the upstream <c>marketplace</c> value.</summary>
    [JsonPropertyName("marketplace")]
    public bool? Marketplace { get; init; }

    /// <summary>Gets the upstream <c>exchange</c> value.</summary>
    [JsonPropertyName("exchange")]
    public bool? Exchange { get; init; }

    /// <summary>Gets the upstream <c>dataApi</c> value.</summary>
    [JsonPropertyName("dataApi")]
    public bool? DataApi { get; init; }

    /// <summary>Gets the upstream <c>auth</c> value.</summary>
    [JsonPropertyName("auth")]
    public bool? Auth { get; init; }

    /// <summary>Gets the upstream <c>stakingV4</c> value.</summary>
    [JsonPropertyName("stakingV4")]
    public bool? StakingV4 { get; init; }

    /// <summary>Gets the upstream <c>chainAndromeda</c> value.</summary>
    [JsonPropertyName("chainAndromeda")]
    public bool? ChainAndromeda { get; init; }

    /// <summary>Gets the upstream <c>stakingV5</c> value.</summary>
    [JsonPropertyName("stakingV5")]
    public bool? StakingV5 { get; init; }

    /// <summary>Gets the upstream <c>stakingV5ActivationEpoch</c> value.</summary>
    [JsonPropertyName("stakingV5ActivationEpoch")]
    public long? StakingV5ActivationEpoch { get; init; }

    /// <summary>Gets the upstream <c>nodeEpochsLeft</c> value.</summary>
    [JsonPropertyName("nodeEpochsLeft")]
    public bool? NodeEpochsLeft { get; init; }

    /// <summary>Gets the upstream <c>transactionProcessor</c> value.</summary>
    [JsonPropertyName("transactionProcessor")]
    public bool? TransactionProcessor { get; init; }

    /// <summary>Gets the upstream <c>transactionCompleted</c> value.</summary>
    [JsonPropertyName("transactionCompleted")]
    public bool? TransactionCompleted { get; init; }

    /// <summary>Gets the upstream <c>transactionBatch</c> value.</summary>
    [JsonPropertyName("transactionBatch")]
    public bool? TransactionBatch { get; init; }

    /// <summary>Gets the upstream <c>deepHistory</c> value.</summary>
    [JsonPropertyName("deepHistory")]
    public bool? DeepHistory { get; init; }

    /// <summary>Gets the upstream <c>elasticCircuitBreaker</c> value.</summary>
    [JsonPropertyName("elasticCircuitBreaker")]
    public bool? ElasticCircuitBreaker { get; init; }

    /// <summary>Gets the upstream <c>statusChecker</c> value.</summary>
    [JsonPropertyName("statusChecker")]
    public bool? StatusChecker { get; init; }

    /// <summary>Gets the upstream <c>nftScamInfo</c> value.</summary>
    [JsonPropertyName("nftScamInfo")]
    public bool? NftScamInfo { get; init; }

    /// <summary>Gets the upstream <c>processNfts</c> value.</summary>
    [JsonPropertyName("processNfts")]
    public bool? ProcessNfts { get; init; }

    /// <summary>Gets the upstream <c>tps</c> value.</summary>
    [JsonPropertyName("tps")]
    public bool? Tps { get; init; }

    /// <summary>Gets the upstream <c>nodesFetch</c> value.</summary>
    [JsonPropertyName("nodesFetch")]
    public bool? NodesFetch { get; init; }

    /// <summary>Gets the upstream <c>tokensFetch</c> value.</summary>
    [JsonPropertyName("tokensFetch")]
    public bool? TokensFetch { get; init; }

    /// <summary>Gets the upstream <c>providersFetch</c> value.</summary>
    [JsonPropertyName("providersFetch")]
    public bool? ProvidersFetch { get; init; }

    /// <summary>Gets the upstream <c>assetsFetch</c> value.</summary>
    [JsonPropertyName("assetsFetch")]
    public bool? AssetsFetch { get; init; }

}
