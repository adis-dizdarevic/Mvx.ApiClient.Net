#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens/{identifier}/supply.</summary>
public sealed class GetTokenSupplyOptions
{
    /// <summary>Gets or sets the <c>denominated</c> filter.</summary>
    public bool? Denominated { get; init; }

}
