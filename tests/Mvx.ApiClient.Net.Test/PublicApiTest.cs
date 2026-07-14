using System.Reflection;
using Mvx.ApiClient.Net.Exceptions;
using Mvx.ApiClient.Net.Models.Network;
using Mvx.ApiClient.Net.Models.XExchange;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class PublicApiTest
{
    [Test]
    public async Task PublicApi_Surface_MatchesExpectedConsumerContracts()
    {
        var publicApi = PublicApiSnapshot.Create(typeof(IMvxApiClient).Assembly);

        if (string.Equals(Environment.GetEnvironmentVariable("MVX_UPDATE_PUBLIC_API"), "true", StringComparison.OrdinalIgnoreCase))
        {
            var baselinePath = Path.Combine(FindRepositoryRoot(), "tests", "Mvx.ApiClient.Net.Test", "PublicApi.Shipped.txt");
            await File.WriteAllLinesAsync(baselinePath, publicApi);
            await File.WriteAllLinesAsync(Path.Combine(AppContext.BaseDirectory, "PublicApi.Shipped.txt"), publicApi);
            return;
        }

        var expectedTypes = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "PublicApi.Shipped.txt"))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        var differences = DescribeDifferences(expectedTypes, publicApi);
        await Assert.That(differences).IsEmpty()
            .Because("the complete public API surface must match the approved baseline");
    }

    [Test]
    public async Task PublicApi_XExchangeClientListMethods_ReturnReadOnlyLists()
    {
        var methods = typeof(IXExchangeClient)
            .GetMethods()
            .Where(method => method.Name is "GetPairsAsync" or "GetTokensAsync" or "GetFarmsAsync")
            .Select(method => method.ReturnType.GetGenericArguments().Single().GetGenericTypeDefinition())
            .ToArray();

        await Assert.That(methods).IsEquivalentTo([
            typeof(IReadOnlyList<>),
            typeof(IReadOnlyList<>),
            typeof(IReadOnlyList<>)
        ]);
    }

    [Test]
    public async Task PublicApi_MvxApiException_IsImmutableAndUsesHttpStatusCode()
    {
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.StatusCode))?.PropertyType).IsEqualTo(typeof(System.Net.HttpStatusCode));
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.StatusCode))?.SetMethod).IsNull();
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.ResponseContent))?.SetMethod).IsNull();
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.RequestUri))?.SetMethod).IsNull();
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.RequestMethod))?.SetMethod).IsNull();
        await Assert.That(typeof(MvxApiException).GetProperty(nameof(MvxApiException.RetryAfter))?.PropertyType).IsEqualTo(typeof(TimeSpan?));
    }

    [Test]
    public async Task PublicApi_ClientMethodSignatures_AreStable()
    {
        await Assert.That(typeof(INetworkClient).GetMethod(nameof(INetworkClient.GetStatsAsync))?.ReturnType).IsEqualTo(typeof(Task<StatsDto>));
        await Assert.That(typeof(INetworkClient).GetMethod(nameof(INetworkClient.GetEconomicsAsync))?.ReturnType).IsEqualTo(typeof(Task<EconomicsDto>));
        await Assert.That(typeof(IXExchangeClient).GetMethod(nameof(IXExchangeClient.GetPairsAsync))?.ReturnType).IsEqualTo(typeof(Task<IReadOnlyList<XExchangePairDto>>));
        await Assert.That(typeof(IXExchangeClient).GetMethod(nameof(IXExchangeClient.GetTokensAsync))?.ReturnType).IsEqualTo(typeof(Task<IReadOnlyList<XExchangeTokenDto>>));
        await Assert.That(typeof(IXExchangeClient).GetMethod(nameof(IXExchangeClient.GetFarmsAsync))?.ReturnType).IsEqualTo(typeof(Task<IReadOnlyList<XExchangeFarmDto>>));
        await Assert.That(typeof(IXExchangeClient).GetMethod(nameof(IXExchangeClient.GetPairAsync))?.GetParameters().Select(parameter => parameter.ParameterType)).IsEquivalentTo([typeof(string), typeof(string), typeof(CancellationToken)]);
        await Assert.That(typeof(IXExchangeClient).GetMethod(nameof(IXExchangeClient.GetTokenAsync))?.GetParameters().Select(parameter => parameter.ParameterType)).IsEquivalentTo([typeof(string), typeof(CancellationToken)]);
        await Assert.That(typeof(MvxApiClientOptions).GetProperty(nameof(MvxApiClientOptions.ConfigureHttpClientBuilder))?.PropertyType).IsEqualTo(typeof(Action<Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>));
    }

    [Test]
    public async Task PublicApi_FinancialValues_UseDecimalAndOptionalUpstreamFlagsRemainNullable()
    {
        await Assert.That(typeof(EconomicsDto).GetProperty(nameof(EconomicsDto.Price))?.PropertyType).IsEqualTo(typeof(decimal));
        await Assert.That(typeof(XExchangeEconomicsDto).GetProperty(nameof(XExchangeEconomicsDto.Price))?.PropertyType).IsEqualTo(typeof(decimal));
        await Assert.That(typeof(XExchangePairDto).GetProperty(nameof(XExchangePairDto.Volume))?.PropertyType).IsEqualTo(typeof(decimal));
        await Assert.That(typeof(XExchangeTokenDto).GetProperty(nameof(XExchangeTokenDto.Price))?.PropertyType).IsEqualTo(typeof(decimal));
        await Assert.That(typeof(XExchangeFarmDto).GetProperty(nameof(XExchangeFarmDto.Price))?.PropertyType).IsEqualTo(typeof(decimal));
        await Assert.That(typeof(XExchangePairDto).GetProperty(nameof(XExchangePairDto.HasFarms))?.PropertyType).IsEqualTo(typeof(bool?));
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "Mvx.ApiClient.Net.slnx")))
        {
            directory = directory.Parent;
        }

        return directory?.FullName
            ?? throw new InvalidOperationException("Could not find the repository root for the public API baseline.");
    }

    private static string DescribeDifferences(IReadOnlyList<string> expected, IReadOnlyList<string> actual)
    {
        var differences = new List<string>();
        var length = Math.Max(expected.Count, actual.Count);

        for (var index = 0; index < length && differences.Count < 20; index++)
        {
            var expectedLine = index < expected.Count ? expected[index] : "<missing>";
            var actualLine = index < actual.Count ? actual[index] : "<missing>";

            if (!string.Equals(expectedLine, actualLine, StringComparison.Ordinal))
            {
                differences.Add($"Line {index + 1}:{Environment.NewLine}  expected: {expectedLine}{Environment.NewLine}  actual:   {actualLine}");
            }
        }

        return string.Join(Environment.NewLine, differences);
    }
}
