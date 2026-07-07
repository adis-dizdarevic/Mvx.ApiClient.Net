using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Mex;
using TUnit.Assertions;
using TUnit.Mocks;
using TUnit.Mocks.Arguments;

namespace Mvx.ApiClient.Net.Test;

public class MexClientTest
{
    [Test]
    public async Task GetMexEconomicsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        var expectedResult = new MexEconomicsDto(
            8045920000000,
            4475040846664,
            0.0000035452649740387483,
            15865206,
            2459773,
            255
        );

        mexClient.GetMexEconomicsAsync(Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexEconomicsAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetMexPairsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        var expectedResult = new List<MexPairDto>
        {
            new(
                "erd1qqqqqqqqqqqqqpgqa0fsfshnff4n76jhcye6k7uvd7qacsq42jpsp6shh2",
                "EGLDMEX-0be9e5",
                "EGLDMEX",
                "EGLDMEXLP",
                25.990377430412764,
                0.0000034236771273863,
                28.054195791907098,
                "MEX-455c57",
                "MEX",
                "MEX",
                0.0000035646835162367443,
                "WEGLD-bd4d79",
                "WEGLD",
                "WEGLD",
                29.12301475738498,
                15589095.555115119,
                22928.67394065124,
                MexPairState.Active,
                MexPairType.Core,
                "xexchange",
                true,
                false,
                1202710,
                65,
                1636895478
            ),
            new(
                "erd1qqqqqqqqqqqqqpgqvsmpxsvnjnr7wfkkpyg8aj7vj2fv7glr2jpsmg79f4",
                "LAUNCHUSDC-2263cb",
                "LAUNCHUSDC",
                "LAUNCHUSDCLP",
                567444523235.0325,
                1,
                0.00020853226988563079,
                "USDC-c76f1f",
                "USDC",
                "WrappedUSDC",
                0.9998080307400676,
                "LAUNCH-3e2258",
                "LAUNCH",
                "LAUNCH",
                0.0002307030977990863,
                72.01737911762847,
                2.011606,
                MexPairState.Active,
                MexPairType.Experimental,
                "xexchange",
                false,
                false,
                341,
                0,
                1656600090
            ),
        };

        mexClient.GetMexPairsAsync(Arg.IsNull<QueryParametersDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var mexPairs = await mexClient.Object.GetMexPairsAsync();
        var result = mexPairs.ToList();

        // assert
        await Assert.That(result).Count().IsEqualTo(2);
        await Assert.That(result).IsEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetMexPairAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        const string baseId = "MEX-455c57";
        const string quoteId = "WEGLD-bd4d79";

        var expectedResult = new MexPairDto(
            "erd1qqqqqqqqqqqqqpgqa0fsfshnff4n76jhcye6k7uvd7qacsq42jpsp6shh2",
            "EGLDMEX-0be9e5",
            "EGLDMEX",
            "EGLDMEXLP",
            27.469775643358084,
            0.00000356224632330205,
            29.10317237842375,
            "MEX-455c57",
            "MEX",
            "MEX",
            0.0000037630062738369422,
            "WEGLD-bd4d79",
            "WEGLD",
            "WrappedEGLD",
            30.862179716983857,
            16472579.082353646,
            30356.871676890976,
            MexPairState.Active,
            MexPairType.Core,
            "xexchange",
            true,
            false,
            1202869,
            157,
            1636895478
        );

        mexClient.GetMexPairAsync(baseId, quoteId, Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexPairAsync(baseId, quoteId);

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetMexPairsCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        const int expectedResult = 2;

        mexClient.GetMexPairsCountAsync(CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexPairsCountAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetMexTokensAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        var expectedResult = new List<MexTokenDto>
        {
            new(
                "MEX-455c57",
                "MEX",
                "MEX",
                0.0000037602764091959637,
                0.00000356974343527048,
                29643.392910079518,
                1208170
            ),
            new(
                "WEGLD-bd4d79",
                "WEGLD",
                "WrappedEGLD",
                30.84248771639467,
                29.174000856617948,
                1367893.3416906688,
                5373325
            )
        };

        mexClient.GetMexTokensAsync(Arg.IsNull<QueryParametersDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var mexTokens = await mexClient.Object.GetMexTokensAsync();
        var result = mexTokens.ToList();

        // assert
        await Assert.That(result).Count().IsEqualTo(2);
        await Assert.That(result).IsEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetMexTokenAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        const string identifier = "WEGLD-bd4d79";
        var expectedResult = new MexTokenDto(
            "WEGLD-bd4d79",
            "WEGLD",
            "WrappedEGLD",
            30.51936058225821,
            29.174000856617948,
            1386016.8362351472,
            5373361
        );

        mexClient.GetMexTokenAsync(identifier, Arg.IsNull<DataSelectionDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexTokenAsync(identifier);

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetMexTokensCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        const int expectedResult = 2;

        mexClient.GetMexTokensCountAsync(CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexTokensCountAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }

    [Test]
    public async Task GetMexFarmsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        var expectedResult = new List<MexFarmDto>
        {
            new(
                MexFarmType.Standard,
                "v1.2",
                "erd1qqqqqqqqqqqqqpgqye633y7k0zd7nedfnp3m48h24qygm5jl2jpslxallh",
                "EGLDMEXF-5bcc57",
                "EGLDMEXF",
                "EGLDMEXLPStaked",
                26.609472637254246,
                "EGLDMEX-0be9e5",
                "EGLDMEX",
                "EGLDMEXLP",
                26.609472637254246,
                "MEX-455c57",
                "MEX",
                "MEX",
                0.000003652205273842815
            ),
            new(
                MexFarmType.Standard,
                "v1.2",
                "erd1qqqqqqqqqqqqqpgqsw9pssy8rchjeyfh8jfafvl3ynum0p9k2jps6lwewp",
                "EGLDUSDCF-8600f8",
                "EGLDUSDCF",
                "EGLDUSDCLPStaked",
                1.5664578010979522,
                "EGLDUSDC-594e5e",
                "EGLDUSDC",
                "EGLDUSDCLP",
                783228900548.9761,
                "MEX-455c57",
                "MEX",
                "MEX",
                0.000003652205273842815
            )
        };

        mexClient.GetMexFarmsAsync(Arg.IsNull<QueryParametersDto?>(), CancellationToken.None).Returns(expectedResult);

        // act
        var mexFarms = await mexClient.Object.GetMexFarmsAsync();
        var result = mexFarms.ToList();

        // assert
        await Assert.That(result).Count().IsEqualTo(2);
        await Assert.That(result).IsEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetMexFarmsCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var mexClient = Mock.Of<IMexClient>();
        const int expectedResult = 2;

        mexClient.GetMexFarmsCountAsync(CancellationToken.None).Returns(expectedResult);

        // act
        var result = await mexClient.Object.GetMexFarmsCountAsync();

        // assert
        await Assert.That(result).IsEqualTo(expectedResult);
    }
}
