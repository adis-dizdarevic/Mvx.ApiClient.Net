#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Transactions;

/// <summary>Optional filters for /transactions/{txHash}.</summary>
public sealed class GetTransactionOptions
{
    /// <summary>Gets or sets the <c>withActionTransferValue</c> filter.</summary>
    public bool? WithActionTransferValue { get; init; }

}
