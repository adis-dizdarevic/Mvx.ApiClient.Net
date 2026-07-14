#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens/count.</summary>
public sealed class GetTokenCountOptions
{
    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public GetTokenCountOptionsType? Type { get; init; }

    /// <summary>Gets or sets the <c>identifier</c> filter.</summary>
    public string? Identifier { get; init; }

    /// <summary>Gets or sets the <c>identifiers</c> filter.</summary>
    public IReadOnlyCollection<string>? Identifiers { get; init; }

    /// <summary>Gets or sets the <c>includeMetaESDT</c> filter.</summary>
    public bool? IncludeMetaESDT { get; init; }

    /// <summary>Gets or sets the <c>mexPairType</c> filter.</summary>
    public IReadOnlyCollection<string>? MexPairType { get; init; }

    /// <summary>Gets or sets the <c>priceSource</c> filter.</summary>
    public GetTokenCountOptionsPriceSource? PriceSource { get; init; }

}
