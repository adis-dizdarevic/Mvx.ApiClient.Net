#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionDetailed response returned by the MultiversX API.</summary>
public sealed class TransactionDetailed
{
    /// <summary>Gets the upstream <c>txHash</c> value.</summary>
    [JsonPropertyName("txHash")]
    public string? TxHash { get; init; }

    /// <summary>Gets the upstream <c>gasLimit</c> value.</summary>
    [JsonPropertyName("gasLimit")]
    public long? GasLimit { get; init; }

    /// <summary>Gets the upstream <c>gasPrice</c> value.</summary>
    [JsonPropertyName("gasPrice")]
    public long? GasPrice { get; init; }

    /// <summary>Gets the upstream <c>gasUsed</c> value.</summary>
    [JsonPropertyName("gasUsed")]
    public long? GasUsed { get; init; }

    /// <summary>Gets the upstream <c>miniBlockHash</c> value.</summary>
    [JsonPropertyName("miniBlockHash")]
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>receiver</c> value.</summary>
    [JsonPropertyName("receiver")]
    public string? Receiver { get; init; }

    /// <summary>Gets the upstream <c>receiverUsername</c> value.</summary>
    [JsonPropertyName("receiverUsername")]
    public string? ReceiverUsername { get; init; }

    /// <summary>Gets the upstream <c>receiverAssets</c> value.</summary>
    [JsonPropertyName("receiverAssets")]
    public AccountAssets? ReceiverAssets { get; init; }

    /// <summary>Gets the upstream <c>receiverShard</c> value.</summary>
    [JsonPropertyName("receiverShard")]
    public long? ReceiverShard { get; init; }

    /// <summary>Gets the upstream <c>round</c> value.</summary>
    [JsonPropertyName("round")]
    public long? Round { get; init; }

    /// <summary>Gets the upstream <c>epoch</c> value.</summary>
    [JsonPropertyName("epoch")]
    public long? Epoch { get; init; }

    /// <summary>Gets the upstream <c>sender</c> value.</summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; init; }

    /// <summary>Gets the upstream <c>senderUsername</c> value.</summary>
    [JsonPropertyName("senderUsername")]
    public string? SenderUsername { get; init; }

    /// <summary>Gets the upstream <c>senderAssets</c> value.</summary>
    [JsonPropertyName("senderAssets")]
    public AccountAssets? SenderAssets { get; init; }

    /// <summary>Gets the upstream <c>senderShard</c> value.</summary>
    [JsonPropertyName("senderShard")]
    public long? SenderShard { get; init; }

    /// <summary>Gets the upstream <c>signature</c> value.</summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the upstream <c>fee</c> value.</summary>
    [JsonPropertyName("fee")]
    public BigInteger? Fee { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the upstream <c>function</c> value.</summary>
    [JsonPropertyName("function")]
    public string? Function { get; init; }

    /// <summary>Gets the upstream <c>action</c> value.</summary>
    [JsonPropertyName("action")]
    public TransactionAction? Action { get; init; }

    /// <summary>Gets the upstream <c>scamInfo</c> value.</summary>
    [JsonPropertyName("scamInfo")]
    public ScamInfo? ScamInfo { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public TransactionDetailedType? Type { get; init; }

    /// <summary>Gets the upstream <c>originalTxHash</c> value.</summary>
    [JsonPropertyName("originalTxHash")]
    public string? OriginalTxHash { get; init; }

    /// <summary>Gets the upstream <c>pendingResults</c> value.</summary>
    [JsonPropertyName("pendingResults")]
    public bool? PendingResults { get; init; }

    /// <summary>Gets the upstream <c>guardianAddress</c> value.</summary>
    [JsonPropertyName("guardianAddress")]
    public string? GuardianAddress { get; init; }

    /// <summary>Gets the upstream <c>guardianSignature</c> value.</summary>
    [JsonPropertyName("guardianSignature")]
    public string? GuardianSignature { get; init; }

    /// <summary>Gets the upstream <c>isRelayed</c> value.</summary>
    [JsonPropertyName("isRelayed")]
    public string? IsRelayed { get; init; }

    /// <summary>Gets the upstream <c>relayer</c> value.</summary>
    [JsonPropertyName("relayer")]
    public string? Relayer { get; init; }

    /// <summary>Gets the upstream <c>relayerSignature</c> value.</summary>
    [JsonPropertyName("relayerSignature")]
    public string? RelayerSignature { get; init; }

    /// <summary>Gets the upstream <c>isScCall</c> value.</summary>
    [JsonPropertyName("isScCall")]
    public bool? IsScCall { get; init; }

    /// <summary>Gets the upstream <c>results</c> value.</summary>
    [JsonPropertyName("results")]
    public IReadOnlyList<SmartContractResult>? Results { get; init; }

    /// <summary>Gets the upstream <c>receipt</c> value.</summary>
    [JsonPropertyName("receipt")]
    public TransactionReceipt? Receipt { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>logs</c> value.</summary>
    [JsonPropertyName("logs")]
    public TransactionLog? Logs { get; init; }

    /// <summary>Gets the upstream <c>operations</c> value.</summary>
    [JsonPropertyName("operations")]
    public IReadOnlyList<TransactionOperation>? Operations { get; init; }

    /// <summary>Gets the upstream <c>senderBlockHash</c> value.</summary>
    [JsonPropertyName("senderBlockHash")]
    public string? SenderBlockHash { get; init; }

    /// <summary>Gets the upstream <c>senderBlockNonce</c> value.</summary>
    [JsonPropertyName("senderBlockNonce")]
    public long? SenderBlockNonce { get; init; }

    /// <summary>Gets the upstream <c>receiverBlockHash</c> value.</summary>
    [JsonPropertyName("receiverBlockHash")]
    public string? ReceiverBlockHash { get; init; }

    /// <summary>Gets the upstream <c>receiverBlockNonce</c> value.</summary>
    [JsonPropertyName("receiverBlockNonce")]
    public long? ReceiverBlockNonce { get; init; }

    /// <summary>Gets the upstream <c>inTransit</c> value.</summary>
    [JsonPropertyName("inTransit")]
    public bool? InTransit { get; init; }

    /// <summary>Gets the upstream <c>relayedVersion</c> value.</summary>
    [JsonPropertyName("relayedVersion")]
    public string? RelayedVersion { get; init; }

}
