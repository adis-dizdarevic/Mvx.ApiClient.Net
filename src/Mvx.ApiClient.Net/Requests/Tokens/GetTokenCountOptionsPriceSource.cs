#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Known values for the <c>priceSource</c> filter on /tokens/count.</summary>
public enum GetTokenCountOptionsPriceSource
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>dataApi</c> value.</summary>
    [EnumMember(Value = "dataApi")]
    DataApi = 1,
    /// <summary>The upstream <c>customUrl</c> value.</summary>
    [EnumMember(Value = "customUrl")]
    CustomUrl = 2,
}
