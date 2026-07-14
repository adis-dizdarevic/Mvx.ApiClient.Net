namespace Mvx.ApiClient.Net;

/// <summary>
/// Buffered content returned by a MultiversX API endpoint, together with its HTTP metadata.
/// </summary>
public sealed class MvxApiContent
{
    private readonly byte[] _content;

    internal MvxApiContent(byte[] content, string? mediaType, string? fileName)
    {
        _content = content;
        MediaType = mediaType;
        FileName = fileName;
    }

    /// <summary>
    /// The response body.
    /// </summary>
    public ReadOnlyMemory<byte> Content => _content;

    /// <summary>
    /// The response media type, when supplied by the server.
    /// </summary>
    public string? MediaType { get; }

    /// <summary>
    /// The response file name, when supplied by the server.
    /// </summary>
    public string? FileName { get; }
}
