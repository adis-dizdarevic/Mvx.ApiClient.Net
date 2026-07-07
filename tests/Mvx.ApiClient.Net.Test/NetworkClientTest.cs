using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Network;
using TUnit.Assertions;
using TUnit.Mocks;
using TUnit.Mocks.Arguments;

namespace Mvx.ApiClient.Net.Test;

public class NetworkClientTest
{
    [Test]
    public async Task GetNetworkStats_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var networkClient = Mock.Of<INetworkClient>();
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

        networkClient.GetNetworkStatsAsync(Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await networkClient.Object.GetNetworkStatsAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetEconomics_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var networkClient = Mock.Of<INetworkClient>();
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

        networkClient.GetEconomicsAsync(Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await networkClient.Object.GetEconomicsAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetNetworkConstants_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var networkClient = Mock.Of<INetworkClient>();
        var expectedResult = new NetworkConstantsDto(
            "MvxChain",
            100_000,
            50_000,
            75_000,
            1
        );

        networkClient.GetNetworkConstantsAsync(Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await networkClient.Object.GetNetworkConstantsAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetAbout_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var networkClient = Mock.Of<INetworkClient>();
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

        networkClient.GetAboutAsync(Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await networkClient.Object.GetAboutAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }
}
