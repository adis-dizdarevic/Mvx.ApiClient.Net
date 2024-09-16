using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Interfaces.Clients;
using Mvx.ApiClient.Models;
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
    public async void GetNetworkStats_NoParameters_ReturnsFullResponse()
    {
        // arrange
        var expectedResult = new Stats(
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

        _networkClient.GetNetworkStats().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _networkClient.GetNetworkStats();

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
    public async void GetNetworkStats_WithSpecificFields_ReturnsResponseWithOnlyRequestedFields()
    {
        // arrange
        
        
        // act
        
        
        // assert
    }
    
    [Fact]
    public async void GetNetworkStats_WithExtractParameter_ReturnsExtractedFieldOnly()
    {
        // arrange
        
        
        // act
        
        
        // assert
    }
    
    [Fact]
    public async void GetNetworkStats_WithLimitAndOffset_ReturnsPagedResponse()
    {
        // arrange
        
        
        // act
        
        
        // assert
    }
}
