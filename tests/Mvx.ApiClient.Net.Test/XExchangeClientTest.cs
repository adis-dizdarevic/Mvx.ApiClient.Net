using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Models.XExchange;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class XExchangeClientTest
{
    [Test]
    public async Task GetEconomicsAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "totalSupply": 8045920000000,
              "circulatingSupply": 4475040846664,
              "price": 0.0000035452649740387483,
              "marketCap": 15865206,
              "volume24h": 2459773,
              "marketPairs": 255
            }
            """));
        var client = CreateClient(handler);

        var result = await client.GetEconomicsAsync();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/economics");
        await Assert.That(result).IsEqualTo(new XExchangeEconomicsDto(8045920000000, 4475040846664, 0.0000035452649740387483m, 15865206m, 2459773m, 255));
    }

    [Test]
    public async Task GetPairsAsync_WithQueryParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse($$"""
            [
              {{PairJson("erd1pair1", "EGLDMEX-0be9e5", "EGLDMEX", "active", "core")}},
              {{PairJson("erd1pair2", "LAUNCHUSDC-2263cb", "LAUNCHUSDC", "active", "experimental")}}
            ]
            """));
        var client = CreateClient(handler);
        var queryOptions = new QueryOptions { Pagination = new Pagination { Limit = 2, Offset = 1 } };

        var result = (await client.GetPairsAsync(queryOptions)).ToList();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/pairs?size=2&from=1");
        await Assert.That(result).Count().IsEqualTo(2);
        await Assert.That(result[0].State).IsEqualTo(XExchangePairState.Active);
        await Assert.That(result[1].Type).IsEqualTo(XExchangePairType.Experimental);
        await Assert.That(result[0].HasFarms).IsTrue();
        await Assert.That(result[0].Price).IsEqualTo(25.990377430412764m);
    }

    [Test]
    public async Task GetPairAsync_WithPathParameters_SendsEscapedDetailPathAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse(PairJson("erd1pair1", "EGLDMEX-0be9e5", "EGLDMEX", "active", "core")));
        var client = CreateClient(handler);

        var result = await client.GetPairAsync("MEX/455c57", "WEGLD bd4d79");

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/pairs/MEX%2F455c57/WEGLD%20bd4d79");
        await Assert.That(result.Id).IsEqualTo("EGLDMEX-0be9e5");
        await Assert.That(result.Type).IsEqualTo(XExchangePairType.Core);
    }

    [Test]
    public async Task GetPairsCountAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("2"));
        var client = CreateClient(handler);

        var result = await client.GetPairsCountAsync();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/pairs/count");
        await Assert.That(result).IsEqualTo(2L);
    }

    [Test]
    public async Task GetTokensAsync_WithPagination_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            [
              {
                "id": "MEX-455c57",
                "symbol": "MEX",
                "name": "MEX",
                "price": 0.0000037602764091959637,
                "previous24hPrice": 0.00000356974343527048,
                "previous24hVolume": 29643.392910079518,
                "tradesCount": 1208170
              }
            ]
            """));
        var client = CreateClient(handler);

        var result = (await client.GetTokensAsync(new QueryOptions { Pagination = new Pagination { Limit = 1 } })).ToList();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/tokens?size=1");
        await Assert.That(result.Single().Id).IsEqualTo("MEX-455c57");
    }

    [Test]
    public async Task GetTokenAsync_WithIdentifier_SendsEscapedDetailPathAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "id": "WEGLD-bd4d79",
              "symbol": "WEGLD",
              "name": "WrappedEGLD",
              "price": 30.51936058225821,
              "previous24hPrice": 29.174000856617948,
              "previous24hVolume": 1386016.8362351472,
              "tradesCount": 5373361
            }
            """));
        var client = CreateClient(handler);

        var result = await client.GetTokenAsync("WEGLD/bd4d79");

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/tokens/WEGLD%2Fbd4d79");
        await Assert.That(result.Symbol).IsEqualTo("WEGLD");
    }

    [Test]
    public async Task GetTokenAsync_EmptyIdentifier_ThrowsArgumentExceptionBeforeRequest()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("{}"));
        var client = CreateClient(handler);

        var exception = await CaptureArgumentException(() => client.GetTokenAsync(""));

        await Assert.That(exception.ParamName).IsEqualTo("identifier");
        await Assert.That(handler.Requests).IsEmpty();
    }

    [Test]
    public async Task GetTokenAsync_RelativeDirectoryIdentifier_ThrowsArgumentExceptionBeforeRequest()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("{}"));
        var client = CreateClient(handler);

        var exception = await CaptureArgumentException(() => client.GetTokenAsync(".."));

        await Assert.That(exception.ParamName).IsEqualTo("identifier");
        await Assert.That(handler.Requests).IsEmpty();
    }

    [Test]
    public async Task GetTokensCountAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("2"));
        var client = CreateClient(handler);

        var result = await client.GetTokensCountAsync();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/tokens/count");
        await Assert.That(result).IsEqualTo(2L);
    }

    [Test]
    public async Task GetFarmsAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            [
              {
                "type": "standard",
                "version": "v1.2",
                "address": "erd1farm",
                "id": "EGLDMEXF-5bcc57",
                "symbol": "EGLDMEXF",
                "name": "EGLDMEXLPStaked",
                "price": 26.609472637254246,
                "farmingId": "EGLDMEX-0be9e5",
                "farmingSymbol": "EGLDMEX",
                "farmingName": "EGLDMEXLP",
                "farmingPrice": 26.609472637254246,
                "farmedId": "MEX-455c57",
                "farmedSymbol": "MEX",
                "farmedName": "MEX",
                "farmedPrice": 0.000003652205273842815
              }
            ]
            """));
        var client = CreateClient(handler);

        var result = (await client.GetFarmsAsync()).ToList();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/farms");
        await Assert.That(result.Single().Type).IsEqualTo(XExchangeFarmType.Standard);
    }

    [Test]
    public async Task GetFarmsCountAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("2"));
        var client = CreateClient(handler);

        var result = await client.GetFarmsCountAsync();

        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/mex/farms/count");
        await Assert.That(result).IsEqualTo(2L);
    }

    private static XExchangeClient CreateClient(HttpMessageHandler handler)
    {
        return new XExchangeClient(new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.multiversx.com")
        });
    }

    private static async Task<ArgumentException> CaptureArgumentException(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (ArgumentException exception)
        {
            return exception;
        }

        throw new InvalidOperationException("Expected ArgumentException was not thrown.");
    }

    private static string PairJson(string address, string id, string symbol, string state, string type)
    {
        return $$"""
            {
              "address": "{{address}}",
              "id": "{{id}}",
              "symbol": "{{symbol}}",
              "name": "{{symbol}}LP",
              "price": 25.990377430412764,
              "basePrevious24hPrice": 0.0000034236771273863,
              "quotePrevious24hPrice": 28.054195791907098,
              "baseId": "MEX-455c57",
              "baseSymbol": "MEX",
              "baseName": "MEX",
              "basePrice": 0.0000035646835162367443,
              "quoteId": "WEGLD-bd4d79",
              "quoteSymbol": "WEGLD",
              "quoteName": "WrappedEGLD",
              "quotePrice": 29.12301475738498,
              "totalValue": 15589095.555115119,
              "volume24h": 22928.67394065124,
              "state": "{{state}}",
              "type": "{{type}}",
              "exchange": "xexchange",
              "hasFarms": true,
              "hasDualFarms": false,
              "tradesCount": 1202710,
              "tradesCount24h": 65,
              "deployedAt": 1636895478
            }
            """;
    }
}
