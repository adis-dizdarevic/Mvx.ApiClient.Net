using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Infrastructure.Serialization;
using Mvx.ApiClient.Net.Models.Api;
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

    [Test]
    public async Task Deserialize_LiveValidatedOpenApiOverrides_PreserveTypedValues()
    {
        var identity = JsonSerializer.Deserialize<Identity>("""
            { "score": 485.9999, "distribution": { "direct": 1 } }
            """, MvxJsonSerializerOptions.Default);
        var nft = JsonSerializer.Deserialize<Nft>("""
            { "media": [{ "url": "https://example.test/nft.png", "fileType": "image/png" }] }
            """, MvxJsonSerializerOptions.Default);
        var token = JsonSerializer.Deserialize<TokenDetailed>("""
            {
              "assets": { "lockedAccounts": {} },
              "ownersHistory": [{ "address": "erd1owner", "timestamp": 123 }]
            }
            """, MvxJsonSerializerOptions.Default);
        var provider = JsonSerializer.Deserialize<Provider>("""
            {
              "stake": "122500000000000000000000",
              "topUp": "514582761972723904309486",
              "locked": "637082761972723904309486",
              "serviceFee": 0.12,
              "apr": 6.31,
              "numUsers": 348,
              "cumulatedRewards": "73091091425635636565665"
            }
            """, MvxJsonSerializerOptions.Default);
        var account = JsonSerializer.Deserialize<Account>("""
            {
              "assets": {
                "name": "System contract",
                "social": { "website": "https://multiversx.com" },
                "tags": ["system", "staking"]
              }
            }
            """, MvxJsonSerializerOptions.Default);
        var batch = JsonSerializer.Deserialize<TransactionBatchResult>("""
            {
              "id": "batch-1",
              "status": "success",
              "transactions": [[{ "value": "12345678901234567890", "status": "success" }]]
            }
            """, MvxJsonSerializerOptions.Default);

        await Assert.That(identity?.Score).IsEqualTo(485.9999m);
        await Assert.That(nft?.Media?.Single().Url).IsEqualTo("https://example.test/nft.png");
        await Assert.That(token?.Assets?.LockedAccounts?.ValueKind).IsEqualTo(JsonValueKind.Object);
        await Assert.That(token?.OwnersHistory?.Single().Address).IsEqualTo("erd1owner");
        await Assert.That(provider?.Stake).IsEqualTo(BigInteger.Parse("122500000000000000000000"));
        await Assert.That(provider?.ServiceFee).IsEqualTo(0.12m);
        await Assert.That(provider?.Apr).IsEqualTo(6.31m);
        await Assert.That(provider?.NumUsers).IsEqualTo(348);
        await Assert.That(account?.Assets?.Social?["website"]).IsEqualTo("https://multiversx.com");
        await Assert.That(batch?.Status).IsEqualTo(TransactionBatchStatus.Success);
        await Assert.That(batch?.Transactions?.Single().Single().Value).IsEqualTo(BigInteger.Parse("12345678901234567890"));
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
