#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Pool;

/// <summary>Optional filters for /pool.</summary>
public sealed class GetTransactionPoolOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

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

    /// <summary>Gets or sets the <c>function</c> filter.</summary>
    public IReadOnlyCollection<string>? Function { get; init; }

}
