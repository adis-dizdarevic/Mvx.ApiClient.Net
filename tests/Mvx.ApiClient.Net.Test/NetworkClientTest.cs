using FluentAssertions;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Network;
using NSubstitute;

namespace Mvx.ApiClient.Net.Test;

public class NetworkClientTest
{
    private readonly IMvxApiClient _mvxApiClient;

    public NetworkClientTest()
    {
        _mvxApiClient = Substitute.For<IMvxApiClient>();
    }

    [Fact]
    public async Task GetNetworkStats_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new StatsDto(
            1_000_000,
            250_000,
            1500,
            1000,
            5000,
            50,
            100_000,
            3,
            5_000_000
        );

        _mvxApiClient.Network.GetNetworkStatsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Network.GetNetworkStatsAsync();

        // assert
        result.Accounts.Should().Be(expectedResult.Accounts);
        result.Blocks.Should().Be(expectedResult.Blocks);
        result.Epoch.Should().Be(expectedResult.Epoch);
        result.RefreshRate.Should().Be(expectedResult.RefreshRate);
        result.RoundsPassed.Should().Be(expectedResult.RoundsPassed);
        result.RoundsPerEpoch.Should().Be(expectedResult.RoundsPerEpoch);
        result.ScResults.Should().Be(expectedResult.ScResults);
        result.Shards.Should().Be(expectedResult.Shards);
        result.Transactions.Should().Be(expectedResult.Transactions);
    }
    
    [Fact]
    public async Task GetEconomics_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new EconomicsDto(
            2_500_000,
            1_500_000,
            1_000_000,
            20.42,
            1_000_000_000,
            7.63,
            8.14,
            6.12,
            200_000
        );

        _mvxApiClient.Network.GetEconomicsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Network.GetEconomicsAsync();

        // assert
        expectedResult.TotalSupply.Should().Be(result.TotalSupply);
        expectedResult.CirculatingSupply.Should().Be(result.CirculatingSupply);
        expectedResult.Staked.Should().Be(result.Staked);
        expectedResult.Price.Should().Be(result.Price);
        expectedResult.MarketCap.Should().Be(result.MarketCap);
        expectedResult.Apr.Should().Be(result.Apr);
        expectedResult.TopUpApr.Should().Be(result.TopUpApr);
        expectedResult.BaseApr.Should().Be(result.BaseApr);
        expectedResult.TokenMarketCap.Should().Be(result.TokenMarketCap);
    }
    
    [Fact]
    public async Task GetNetworkConstants_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new NetworkConstantsDto(
            "MvxChain",
            100_000,
            50_000,
            75_000,
            1
        );

        _mvxApiClient.Network.GetNetworkConstantsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Network.GetNetworkConstantsAsync();

        // assert
        expectedResult.ChainId.Should().Be(result.ChainId);
        expectedResult.GasPerDataByte.Should().Be(result.GasPerDataByte);
        expectedResult.MinGasLimit.Should().Be(result.MinGasLimit);
        expectedResult.MinGasPrice.Should().Be(result.MinGasPrice);
        expectedResult.MinTransactionVersion.Should().Be(result.MinTransactionVersion);
    }
    
    [Fact]
    public async Task GetAbout_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new AboutDto(
            "1.5.0",
            "1.2.0",
            "MvX Network",
            "cluster-1",
            "2.5.3",
            "2.1.1",
            "2.0.4",
            "1.0.2",
            new FeaturesDto(false, true, true, true)
        );

        _mvxApiClient.Network.GetAboutAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Network.GetAboutAsync();

        // assert
        expectedResult.AppVersion.Should().Be(result.AppVersion);
        expectedResult.PluginsVersion.Should().Be(result.PluginsVersion);
        expectedResult.Network.Should().Be(result.Network);
        expectedResult.Cluster.Should().Be(result.Cluster);
        expectedResult.Version.Should().Be(result.Version);
        expectedResult.IndexerVersion.Should().Be(result.IndexerVersion);
        expectedResult.GatewayVersion.Should().Be(result.GatewayVersion);
        expectedResult.ScamEngineVersion.Should().Be(result.ScamEngineVersion);
        expectedResult.Features!.UpdateCollectionExtraDetails.Should().Be(result.Features!.UpdateCollectionExtraDetails);
        expectedResult.Features!.Marketplace.Should().Be(result.Features!.Marketplace);
        expectedResult.Features!.Exchange.Should().Be(result.Features!.Exchange);
        expectedResult.Features!.DataApi.Should().Be(result.Features!.DataApi);
    }
}
