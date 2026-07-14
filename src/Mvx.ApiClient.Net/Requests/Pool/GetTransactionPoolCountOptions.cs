#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Pool;

/// <summary>Optional filters for /pool/count.</summary>
public sealed class GetTransactionPoolCountOptions
{
    /// <summary>Gets or sets the <c>sender</c> filter.</summary>
    public string? Sender { get; init; }

    /// <summary>Gets or sets the <c>receiver</c> filter.</summary>
    public string? Receiver { get; init; }

    /// <summary>Gets or sets the <c>senderShard</c> filter.</summary>
    public long? SenderShard { get; init; }

    /// <summary>Gets or sets the <c>receiverShard</c> filter.</summary>
    public long? ReceiverShard { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public string? Type { get; init; }

}
