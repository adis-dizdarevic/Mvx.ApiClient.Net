using System.Reflection;
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure.Serialization;

internal static class EnumWireName
{
    public static string GetValue<TEnum>(TEnum value)
        where TEnum : struct, Enum
    {
        return GetValue(typeof(TEnum), value);
    }

    public static string GetValue(Type enumType, object value)
    {
        var name = Enum.GetName(enumType, value)
            ?? throw new ArgumentOutOfRangeException(nameof(value), value, $"Value is not defined by {enumType.Name}.");
        var field = enumType.GetField(name, BindingFlags.Public | BindingFlags.Static)!;

        return field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? name;
    }
}
