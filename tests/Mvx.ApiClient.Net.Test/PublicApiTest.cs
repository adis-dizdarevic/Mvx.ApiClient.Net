using System.Reflection;
using Mvx.ApiClient.Net.Exceptions;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class PublicApiTest
{
    [Test]
    public async Task PublicApi_Surface_MatchesExpectedConsumerContracts()
    {
        var publicTypes = typeof(IMvxApiClient).Assembly
            .GetExportedTypes()
            .Select(type => type.FullName!)
            .Order()
            .ToArray();

        var expectedTypes = new[]
        {
            "Mvx.ApiClient.Net.DataSelection",
            "Mvx.ApiClient.Net.IMvxApiClient",
            "Mvx.ApiClient.Net.INetworkClient",
            "Mvx.ApiClient.Net.IXExchangeClient",
            "Mvx.ApiClient.Net.MvxApiClientOptions",
            "Mvx.ApiClient.Net.NetworkType",
            "Mvx.ApiClient.Net.Pagination",
            "Mvx.ApiClient.Net.QueryOptions",
            "Mvx.ApiClient.Net.ServiceCollectionExtensions",
            "Mvx.ApiClient.Net.Exceptions.MvxApiException",
            "Mvx.ApiClient.Net.Models.Network.AboutDto",
            "Mvx.ApiClient.Net.Models.Network.EconomicsDto",
            "Mvx.ApiClient.Net.Models.Network.FeaturesDto",
            "Mvx.ApiClient.Net.Models.Network.NetworkConstantsDto",
            "Mvx.ApiClient.Net.Models.Network.StatsDto",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangeEconomicsDto",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangeFarmDto",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangeFarmType",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangePairDto",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangePairState",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangePairType",
            "Mvx.ApiClient.Net.Models.XExchange.XExchangeTokenDto"
        };

        await Assert.That(publicTypes).IsEquivalentTo(expectedTypes);
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
    }
}
