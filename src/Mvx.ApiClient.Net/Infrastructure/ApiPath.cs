using System.Globalization;

namespace Mvx.ApiClient.Net.Infrastructure;

internal static class ApiPath
{
    public static string EscapeRequired(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Path segment cannot be null or empty.", parameterName);
        }

        if (value is "." or "..")
        {
            throw new ArgumentException("Path segment cannot be a relative directory marker.", parameterName);
        }

        return Uri.EscapeDataString(value);
    }

    public static string FormatNumber<T>(T value)
        where T : struct, IFormattable
    {
        return value.ToString(null, CultureInfo.InvariantCulture);
    }
}
