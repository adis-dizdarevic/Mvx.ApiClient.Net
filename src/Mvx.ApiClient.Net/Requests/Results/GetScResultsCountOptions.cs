#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Results;

/// <summary>Optional filters for /results/count.</summary>
public sealed class GetScResultsCountOptions
{
    /// <summary>Gets or sets the <c>sender</c> filter.</summary>
    public string? Sender { get; init; }

    /// <summary>Gets or sets the <c>receiver</c> filter.</summary>
    public string? Receiver { get; init; }

    /// <summary>Gets or sets the <c>function</c> filter.</summary>
    public IReadOnlyCollection<string>? Function { get; init; }

}
