#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/transactions/count.</summary>
public sealed class GetAccountTransactionsCountOptions
{
    /// <summary>Gets or sets the <c>sender</c> filter.</summary>
    public string? Sender { get; init; }

    /// <summary>Gets or sets the <c>receiver</c> filter.</summary>
    public IReadOnlyCollection<string>? Receiver { get; init; }

    /// <summary>Gets or sets the <c>token</c> filter.</summary>
    public string? Token { get; init; }

    /// <summary>Gets or sets the <c>senderShard</c> filter.</summary>
    public long? SenderShard { get; init; }

    /// <summary>Gets or sets the <c>receiverShard</c> filter.</summary>
    public long? ReceiverShard { get; init; }

    /// <summary>Gets or sets the <c>miniBlockHash</c> filter.</summary>
    public string? MiniBlockHash { get; init; }

    /// <summary>Gets or sets the <c>hashes</c> filter.</summary>
    public IReadOnlyCollection<string>? Hashes { get; init; }

    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public GetAccountTransactionsCountOptionsStatus? Status { get; init; }

    /// <summary>Gets or sets the <c>function</c> filter.</summary>
    public IReadOnlyCollection<string>? Function { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>round</c> filter.</summary>
    public long? Round { get; init; }

    /// <summary>Gets or sets the <c>senderOrReceiver</c> filter.</summary>
    public string? SenderOrReceiver { get; init; }

    /// <summary>Gets or sets the <c>isRelayed</c> filter.</summary>
    public bool? IsRelayed { get; init; }

    /// <summary>Gets or sets the <c>isScCall</c> filter.</summary>
    public bool? IsScCall { get; init; }

    /// <summary>Gets or sets the <c>withRelayedScresults</c> filter.</summary>
    public bool? WithRelayedScresults { get; init; }

}
