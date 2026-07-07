namespace Mvx.ApiClient.Net.Exceptions;

/// <summary>
/// The exception that is thrown when the MultiversX API returns a status code between 400 and 499
/// </summary>
public sealed class MvxApiException : Exception
{
    /// <summary>
    /// Initializes a new API exception.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="error">The API error label or HTTP reason phrase.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="responseContent">The raw response content, when available.</param>
    public MvxApiException(string message, string error, int statusCode, string? responseContent = null) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
    /// <summary>
    /// The API error label or HTTP reason phrase.
    /// </summary>
    public string Error { get; set; }

    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// The raw response content, when available.
    /// </summary>
    public string? ResponseContent { get; set; }
}
