namespace Mvx.ApiClient.Net;

/// <summary>
/// Configures optional query parameters for MultiversX API requests.
/// </summary>
public sealed class QueryOptions
{
    /// <summary>
    /// Gets or sets pagination options.
    /// </summary>
    public Pagination? Pagination { get; set; }

    /// <summary>
    /// Gets or sets response field selection options.
    /// </summary>
    public DataSelection? Data { get; set; }
}
