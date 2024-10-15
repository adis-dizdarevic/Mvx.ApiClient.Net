using Mvx.ApiClient.Interfaces.Clients;
using Mvx.ApiClient.Models.Network;
using NSubstitute;

namespace Mvx.ApiClient.Test;

public class NetworkClientTest
{
    private readonly INetworkClient _networkClient;

    public NetworkClientTest()
    {
        _networkClient = Substitute.For<INetworkClient>();
    }

    [Fact]
    public async void GetNetworkStats_NoParameters_ReturnsExpectedRecord()
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

        _networkClient.GetNetworkStatsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _networkClient.GetNetworkStatsAsync();

        // assert
        Assert.Equal(expectedResult.Accounts, result.Accounts);
        Assert.Equal(expectedResult.Blocks, result.Blocks);
        Assert.Equal(expectedResult.Epoch, result.Epoch);
        Assert.Equal(expectedResult.RefreshRate, result.RefreshRate);
        Assert.Equal(expectedResult.RoundsPassed, result.RoundsPassed);
        Assert.Equal(expectedResult.RoundsPerEpoch, result.RoundsPerEpoch);
        Assert.Equal(expectedResult.ScResults, result.ScResults);
        Assert.Equal(expectedResult.Shards, result.Shards);
        Assert.Equal(expectedResult.Transactions, result.Transactions);
    }
    
    [Fact]
    public async void GetEconomics_NoParameters_ReturnsExpectedRecord()
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

        _networkClient.GetEconomicsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _networkClient.GetEconomicsAsync();

        // assert
        Assert.Equal(expectedResult.TotalSupply, result.TotalSupply);
        Assert.Equal(expectedResult.CirculatingSupply, result.CirculatingSupply);
        Assert.Equal(expectedResult.Staked, result.Staked);
        Assert.Equal(expectedResult.Price, result.Price);
        Assert.Equal(expectedResult.MarketCap, result.MarketCap);
        Assert.Equal(expectedResult.Apr, result.Apr);
        Assert.Equal(expectedResult.TopUpApr, result.TopUpApr);
        Assert.Equal(expectedResult.BaseApr, result.BaseApr);
        Assert.Equal(expectedResult.TokenMarketCap, result.TokenMarketCap);
    }
    
    [Fact]
    public async void GetNetworkConstants_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new NetworkConstantsDto(
            "MvxChain",
            100_000,
            50_000,
            75_000,
            1
        );

        _networkClient.GetNetworkConstantsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _networkClient.GetNetworkConstantsAsync();

        // assert
        Assert.Equal(expectedResult.ChainId, result.ChainId);
        Assert.Equal(expectedResult.GasPerDataByte, result.GasPerDataByte);
        Assert.Equal(expectedResult.MinGasLimit, result.MinGasLimit);
        Assert.Equal(expectedResult.MinGasPrice, result.MinGasPrice);
        Assert.Equal(expectedResult.MinTransactionVersion, result.MinTransactionVersion);
    }
    
    [Fact]
    public async void GetAbout_NoParameters_ReturnsExpectedRecord()
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

        _networkClient.GetAboutAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _networkClient.GetAboutAsync();

        // assert
        Assert.Equal(expectedResult.AppVersion, result.AppVersion);
        Assert.Equal(expectedResult.PluginsVersion, result.PluginsVersion);
        Assert.Equal(expectedResult.Network, result.Network);
        Assert.Equal(expectedResult.Cluster, result.Cluster);
        Assert.Equal(expectedResult.Version, result.Version);
        Assert.Equal(expectedResult.IndexerVersion, result.IndexerVersion);
        Assert.Equal(expectedResult.GatewayVersion, result.GatewayVersion);
        Assert.Equal(expectedResult.ScamEngineVersion, result.ScamEngineVersion);
        Assert.Equal(expectedResult?.Features?.UpdateCollectionExtraDetails, result?.Features?.UpdateCollectionExtraDetails);
        Assert.Equal(expectedResult?.Features?.Marketplace, result?.Features?.Marketplace);
        Assert.Equal(expectedResult?.Features?.Exchange, result?.Features?.Exchange);
        Assert.Equal(expectedResult?.Features?.DataApi, result?.Features?.DataApi);
    }
}
