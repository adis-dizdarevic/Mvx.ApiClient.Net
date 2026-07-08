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

        var expectedTypes = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "PublicApi.Shipped.txt"))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Order()
            .ToArray();

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
