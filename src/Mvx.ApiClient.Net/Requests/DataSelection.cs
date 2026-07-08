namespace Mvx.ApiClient.Net;

/// <summary>
/// Selects fields or extracted values returned by MultiversX API endpoints.
/// </summary>
public sealed class DataSelection
{
    /// <summary>
    /// Gets or sets the response fields to request.
    /// </summary>
    /// <remarks>
    /// Values are sent through the API's <c>fields</c> query parameter and are URL encoded by the client.
    /// </remarks>
    public IEnumerable<string>? Fields { get; set; }

    /// <summary>
    /// Gets or sets a scalar field to extract from the response.
    /// </summary>
    /// <remarks>
    /// Values are sent through the API's <c>extract</c> query parameter and are URL encoded by the client.
    /// </remarks>
    public string? Extract { get; set; }
}
