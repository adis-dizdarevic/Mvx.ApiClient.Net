using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure;

internal sealed class ApiRequestExecutor
{
    private readonly HttpClient _httpClient;

    public ApiRequestExecutor(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string requestPath, QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        return await GetJsonAsync<T>(requestPath, QueryParameters.From(queryOptions), cancellationToken);
    }

    internal async Task<T> GetJsonAsync<T>(string requestPath, QueryParameters? queryParameters = null, CancellationToken cancellationToken = default)
    {
        using var response = await SendAsync(requestPath, queryParameters, cancellationToken);
        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<T>(responseStream, MvxJsonSerializerOptions.Default, cancellationToken);

        if (result is null)
        {
            throw new HttpRequestException($"No response data or could not deserialize to type {typeof(T)}.");
        }

        return result;
    }

    internal async Task<string> GetStringAsync(string requestPath, QueryParameters? queryParameters = null, CancellationToken cancellationToken = default)
    {
        using var response = await SendAsync(requestPath, queryParameters, cancellationToken);

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    internal async Task<MvxApiContent> GetContentAsync(string requestPath, QueryParameters? queryParameters = null, CancellationToken cancellationToken = default)
    {
        using var response = await SendAsync(requestPath, queryParameters, cancellationToken);
        var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        var mediaType = response.Content.Headers.ContentType?.MediaType;
        var fileName = response.Content.Headers.ContentDisposition?.FileNameStar
            ?? response.Content.Headers.ContentDisposition?.FileName?.Trim('"');

        return new MvxApiContent(content, mediaType, fileName);
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryOptions? queryOptions = null)
    {
        return BuildRequestUri(baseAddress, requestPath, QueryParameters.From(queryOptions));
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryParameters? queryParameters)
    {
        ArgumentNullException.ThrowIfNull(baseAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(requestPath);
        ValidateRelativeRequestPath(requestPath);

        var queryString = queryParameters is null
            ? string.Empty
            : string.Join("&", queryParameters.Values.Select(parameter =>
                $"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}"));
        var separator = requestPath.Contains('?', StringComparison.Ordinal) ? "&" : "?";
        var fullUri = string.IsNullOrEmpty(queryString) ? requestPath : $"{requestPath}{separator}{queryString}";

        return new Uri(baseAddress, fullUri);
    }

    private static void ValidateRelativeRequestPath(string requestPath)
    {
        if (requestPath.StartsWith("/", StringComparison.Ordinal)
            || Uri.TryCreate(requestPath, UriKind.Absolute, out _))
        {
            throw new ArgumentException("Request path must be relative so the configured API base path is preserved.", nameof(requestPath));
        }

        if (requestPath.Contains("#", StringComparison.Ordinal)
            || requestPath.Contains("\\", StringComparison.Ordinal))
        {
            throw new ArgumentException("Request path cannot contain a URI fragment or backslash.", nameof(requestPath));
        }

        var pathOnly = requestPath.Split('?', 2)[0];
        if (pathOnly.Split('/').Any(segment => Uri.UnescapeDataString(segment) is "." or ".."))
        {
            throw new ArgumentException("Request path cannot contain relative directory segments.", nameof(requestPath));
        }
    }

    private async Task<HttpResponseMessage> SendAsync(
        string requestPath,
        QueryParameters? queryParameters,
        CancellationToken cancellationToken)
    {
        var baseAddress = _httpClient.BaseAddress
            ?? throw new InvalidOperationException("The HTTP client must have a base address before sending a request.");
        var requestUri = BuildRequestUri(baseAddress, requestPath, queryParameters);
        using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        try
        {
            response.EnsureSuccessStatusCode();
            return response;
        }
        catch
        {
            response.Dispose();
            throw;
        }
    }

}
