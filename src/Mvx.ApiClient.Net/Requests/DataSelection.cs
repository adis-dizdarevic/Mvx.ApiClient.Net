namespace Mvx.ApiClient.Net;

/// <summary>
/// Selects fields or extracted values returned by MultiversX API endpoints.
/// </summary>
public sealed class DataSelection
{
    /// <summary>
    /// Gets or sets the response fields to request.
    /// </summary>
    public IEnumerable<string>? Fields { get; set; }

    /// <summary>
    /// Gets or sets a scalar field to extract from the response.
    /// </summary>
    public string? Extract { get; set; }
}
