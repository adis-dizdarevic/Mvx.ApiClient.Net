#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the DappConfig response returned by the MultiversX API.</summary>
public sealed class DappConfig
{
    /// <summary>Gets the upstream <c>id</c> value.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>egldLabel</c> value.</summary>
    [JsonPropertyName("egldLabel")]
    public string? EgldLabel { get; init; }

    /// <summary>Gets the upstream <c>decimals</c> value.</summary>
    [JsonPropertyName("decimals")]
    public string? Decimals { get; init; }

    /// <summary>Gets the upstream <c>egldDenomination</c> value.</summary>
    [JsonPropertyName("egldDenomination")]
    public string? EgldDenomination { get; init; }

    /// <summary>Gets the upstream <c>gasPerDataByte</c> value.</summary>
    [JsonPropertyName("gasPerDataByte")]
    public string? GasPerDataByte { get; init; }

    /// <summary>Gets the upstream <c>apiTimeout</c> value.</summary>
    [JsonPropertyName("apiTimeout")]
    public string? ApiTimeout { get; init; }

    /// <summary>Gets the upstream <c>walletConnectDeepLink</c> value.</summary>
    [JsonPropertyName("walletConnectDeepLink")]
    public string? WalletConnectDeepLink { get; init; }

    /// <summary>Gets the upstream <c>walletConnectBridgeAddresses</c> value.</summary>
    [JsonPropertyName("walletConnectBridgeAddresses")]
    public IReadOnlyList<string>? WalletConnectBridgeAddresses { get; init; }

    /// <summary>Gets the upstream <c>walletAddress</c> value.</summary>
    [JsonPropertyName("walletAddress")]
    public string? WalletAddress { get; init; }

    /// <summary>Gets the upstream <c>apiAddress</c> value.</summary>
    [JsonPropertyName("apiAddress")]
    public string? ApiAddress { get; init; }

    /// <summary>Gets the upstream <c>explorerAddress</c> value.</summary>
    [JsonPropertyName("explorerAddress")]
    public string? ExplorerAddress { get; init; }

    /// <summary>Gets the upstream <c>chainId</c> value.</summary>
    [JsonPropertyName("chainId")]
    public string? ChainId { get; init; }

    /// <summary>Gets the upstream <c>refreshRate</c> value.</summary>
    [JsonPropertyName("refreshRate")]
    public long? RefreshRate { get; init; }

}
