using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Infrastructure.Serialization;
using Mvx.ApiClient.Net.Models.XExchange;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class JsonSerializationTest
{
    [Test]
    public async Task Deserialize_NumberEncodedAsString_ReadsTypedNumericProperties()
    {
        var result = JsonSerializer.Deserialize<NumericResponse>("""
            { "count": "123", "price": "12.5001" }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(result).IsEqualTo(new NumericResponse(123, 12.5001m));
    }

    [Test]
    public async Task Deserialize_BigIntegerFromString_PreservesArbitraryPrecision()
    {
        const string amount = "12345678901234567890123456789012345678901234567890";

        var result = JsonSerializer.Deserialize<AmountResponse>($$"""
            { "amount": "{{amount}}" }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(result?.Amount).IsEqualTo(BigInteger.Parse(amount));
    }

    [Test]
    public async Task Deserialize_BigIntegerFromJsonNumber_PreservesArbitraryPrecision()
    {
        const string amount = "12345678901234567890123456789012345678901234567890";

        var result = JsonSerializer.Deserialize<AmountResponse>($$"""
            { "amount": {{amount}} }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(result?.Amount).IsEqualTo(BigInteger.Parse(amount));
    }

    [Test]
    public async Task Deserialize_UnknownUpstreamEnumValue_UsesUnknownFallback()
    {
        var result = JsonSerializer.Deserialize<EnumResponse>("""
            { "state": "new-upstream-state" }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(result?.State).IsEqualTo(XExchangePairState.Unknown);
    }

    [Test]
    public async Task Deserialize_KnownEnumValue_IsCaseInsensitive()
    {
        var result = JsonSerializer.Deserialize<EnumResponse>("""
            { "state": "aCtIvE" }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(result?.State).IsEqualTo(XExchangePairState.Active);
    }

    [Test]
    public async Task QueryParameters_EnumMemberValue_UsesExplicitWireName()
    {
        var parameters = new QueryParameters().AddEnum("status", TestStatus.ReadyForUse);

        var result = ApiRequestExecutor.BuildRequestUri(new Uri("https://api.multiversx.com/"), "items", parameters);

        await Assert.That(result.PathAndQuery).IsEqualTo("/items?status=ready-for-use");
    }

    [Test]
    public async Task QueryParameters_UnknownEnumValue_IsRejectedBeforeRequest()
    {
        var parameters = new QueryParameters();

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => parameters.AddEnum("state", XExchangePairState.Unknown));

        await Assert.That(exception.Message).Contains("Unknown enum values cannot be sent");
    }

    private sealed record NumericResponse(long Count, decimal Price);

    private sealed record AmountResponse(BigInteger Amount);

    private sealed record EnumResponse(XExchangePairState State);

    private enum TestStatus
    {
        [EnumMember(Value = "ready-for-use")]
        ReadyForUse
    }
}
