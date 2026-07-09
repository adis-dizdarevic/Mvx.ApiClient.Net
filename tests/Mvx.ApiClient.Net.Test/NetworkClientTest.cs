using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Models.Network;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class NetworkClientTest
{
    [Test]
    public async Task GetStatsAsync_SendsExpectedRequestAndDeserializesResponse()
    {
        // arrange
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "accounts": 1000000,
              "blocks": 250000,
              "epoch": 1500,
              "refreshRate": 1000,
              "roundsPassed": 5000,
              "roundsPerEpoch": 50,
              "shards": 3,
              "transactions": 5000000,
              "scResults": 100000
            }
            """));
        var client = CreateClient(handler);

        // act
        var result = await client.GetStatsAsync();

        // assert
        await Assert.That(handler.Requests.Single().Method).IsEqualTo(HttpMethod.Get);
        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/stats");
        await Assert.That(result).IsEqualTo(new StatsDto(1_000_000, 250_000, 1500, 1000, 5000, 50, 3, 5_000_000, 100_000));
    }

    [Test]
    public async Task GetEconomicsAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        // arrange
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "totalSupply": 2500000,
              "circulatingSupply": 1500000,
              "staked": 1000000,
              "price": 20.42,
              "marketCap": 1000000000,
              "apr": 7.63,
              "topUpApr": 8.14,
              "baseApr": 6.12,
              "tokenMarketCap": 200000
            }
            """));
        var client = CreateClient(handler);

        // act
        var result = await client.GetEconomicsAsync();

        // assert
        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/economics");
        await Assert.That(result).IsEqualTo(new EconomicsDto(2_500_000, 1_500_000, 1_000_000, 20.42m, 1_000_000_000m, 7.63m, 8.14m, 6.12m, 200_000m));
    }

    [Test]
    public async Task GetConstantsAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        // arrange
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "chainId": "1",
              "gasPerDataByte": 1500,
              "minGasLimit": 50000,
              "minGasPrice": 1000000000,
              "minTransactionVersion": 2
            }
            """));
        var client = CreateClient(handler);

        // act
        var result = await client.GetConstantsAsync();

        // assert
        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/constants");
        await Assert.That(result).IsEqualTo(new NetworkConstantsDto("1", 1500, 50_000, 1_000_000_000, 2));
    }

    [Test]
    public async Task GetAboutAsync_NoParameters_SendsExpectedRequestAndDeserializesResponse()
    {
        // arrange
        var handler = new TestHttpMessageHandler(_ => TestHttpMessageHandler.JsonResponse("""
            {
              "appVersion": "1.5.0",
              "pluginsVersion": "1.2.0",
              "network": "mainnet",
              "cluster": "mainnet-cluster",
              "version": "2.5.3",
              "indexerVersion": "2.1.1",
              "gatewayVersion": "2.0.4",
              "scamEngineVersion": "1.0.2",
              "features": {
                "updateCollectionExtraDetails": false,
                "marketplace": true,
                "exchange": true,
                "dataApi": true
              }
            }
            """));
        var client = CreateClient(handler);

        // act
        var result = await client.GetAboutAsync();

        // assert
        await Assert.That(handler.Requests.Single().Uri.PathAndQuery).IsEqualTo("/about");
        await Assert.That(result.Network).IsEqualTo("mainnet");
        await Assert.That(result.Features).IsEqualTo(new FeaturesDto(false, true, true, true));
    }

    private static NetworkClient CreateClient(HttpMessageHandler handler)
    {
        return new NetworkClient(new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.multiversx.com")
        });
    }
}
