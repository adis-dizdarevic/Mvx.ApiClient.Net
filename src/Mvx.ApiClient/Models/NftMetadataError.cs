using Mvx.ApiClient.Enums;

namespace Mvx.ApiClient.Models;

public class NftMetadataError
{
    /// <summary>
    /// The error code
    /// </summary>
    public ErrorCode Code { get; }

    /// <summary>
    /// The error message
    /// </summary>
    public string Message { get; } = string.Empty;

    /// <summary>
    /// The timestamp when the error has occurred
    /// </summary>
    public long Timestamp { get; }
}
