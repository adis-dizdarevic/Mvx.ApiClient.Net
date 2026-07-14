using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>
/// Represents the current state of a transaction batch.
/// </summary>
public sealed class TransactionBatchResult
{
    /// <summary>Gets the caller-defined batch identifier.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the aggregate batch status.</summary>
    [JsonPropertyName("status")]
    public TransactionBatchStatus? Status { get; init; }

    /// <summary>Gets the ordered transaction groups in the batch.</summary>
    [JsonPropertyName("transactions")]
    public IReadOnlyList<IReadOnlyList<TransactionBatchTransaction>>? Transactions { get; init; }
}

/// <summary>
/// Represents one transaction and its execution state within a batch.
/// </summary>
public sealed class TransactionBatchTransaction
{
    /// <summary>Gets the network chain identifier.</summary>
    [JsonPropertyName("chainID")]
    public string? ChainId { get; init; }

    /// <summary>Gets the optional base64-encoded transaction data.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    /// <summary>Gets the transaction gas limit.</summary>
    [JsonPropertyName("gasLimit")]
    public long? GasLimit { get; init; }

    /// <summary>Gets the transaction gas price.</summary>
    [JsonPropertyName("gasPrice")]
    public long? GasPrice { get; init; }

    /// <summary>Gets the sender nonce.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the receiver address.</summary>
    [JsonPropertyName("receiver")]
    public string? Receiver { get; init; }

    /// <summary>Gets the sender address.</summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; init; }

    /// <summary>Gets the transaction signature.</summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; init; }

    /// <summary>Gets the atomic EGLD value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the transaction version.</summary>
    [JsonPropertyName("version")]
    public long? Version { get; init; }

    /// <summary>Gets the optional transaction options bit field.</summary>
    [JsonPropertyName("options")]
    public long? Options { get; init; }

    /// <summary>Gets the optional guardian address.</summary>
    [JsonPropertyName("guardian")]
    public string? Guardian { get; init; }

    /// <summary>Gets the optional guardian signature.</summary>
    [JsonPropertyName("guardianSignature")]
    public string? GuardianSignature { get; init; }

    /// <summary>Gets the transaction hash after submission.</summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>Gets the transaction execution status within the batch.</summary>
    [JsonPropertyName("status")]
    public BatchTransactionStatus? Status { get; init; }

    /// <summary>Gets an upstream error message when submission failed.</summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}

/// <summary>Known aggregate transaction-batch states.</summary>
public enum TransactionBatchStatus
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The batch is pending.</summary>
    [EnumMember(Value = "pending")]
    Pending = 1,
    /// <summary>The batch completed successfully.</summary>
    [EnumMember(Value = "success")]
    Success = 2,
    /// <summary>The batch is invalid.</summary>
    [EnumMember(Value = "invalid")]
    Invalid = 3,
    /// <summary>The batch was dropped.</summary>
    [EnumMember(Value = "dropped")]
    Dropped = 4
}

/// <summary>Known states for an individual transaction in a batch.</summary>
public enum BatchTransactionStatus
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The transaction is pending.</summary>
    [EnumMember(Value = "pending")]
    Pending = 1,
    /// <summary>The transaction is invalid.</summary>
    [EnumMember(Value = "invalid")]
    Invalid = 2,
    /// <summary>The transaction was dropped.</summary>
    [EnumMember(Value = "dropped")]
    Dropped = 3,
    /// <summary>The transaction completed successfully.</summary>
    [EnumMember(Value = "success")]
    Success = 4
}
