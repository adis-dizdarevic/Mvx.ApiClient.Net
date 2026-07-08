using System.Net;

namespace Mvx.ApiClient.Net.Exceptions;

/// <summary>
/// The exception that is thrown when the MultiversX API returns a non-success status code.
/// </summary>
public sealed class MvxApiException : Exception
{
    /// <summary>
    /// Initializes a new API exception.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="error">The API error label or HTTP reason phrase.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="requestUri">The request URI, when available.</param>
    /// <param name="requestMethod">The request method, when available.</param>
    /// <param name="responseContent">The raw response content, when available.</param>
    public MvxApiException(
        string message,
        string? error,
        HttpStatusCode statusCode,
        Uri? requestUri = null,
        HttpMethod? requestMethod = null,
        string? responseContent = null) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
        RequestUri = requestUri;
        RequestMethod = requestMethod;
        ResponseContent = responseContent;
    }

    /// <summary>
    /// The API error label or HTTP reason phrase.
    /// </summary>
    public string? Error { get; }

    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// The request URI, when available.
    /// </summary>
    public Uri? RequestUri { get; }

    /// <summary>
    /// The request method, when available.
    /// </summary>
    public HttpMethod? RequestMethod { get; }

    /// <summary>
    /// The raw response content, when available.
    /// </summary>
    public string? ResponseContent { get; }
}
