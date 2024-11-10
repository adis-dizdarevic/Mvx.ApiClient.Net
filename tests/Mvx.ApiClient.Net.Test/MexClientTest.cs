using FluentAssertions;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Mex;
using Mvx.ApiClient.Net.Models.Network;
using NSubstitute;

namespace Mvx.ApiClient.Net.Test;

public class MexClientTest
{
    private readonly IMvxApiClient _mvxApiClient;

    public MexClientTest()
    {
        _mvxApiClient = Substitute.For<IMvxApiClient>();
    }

    [Fact]
    public async Task GetMexEconomicsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        var expectedResult = new MexEconomicsDto(
            8045920000000,
            4475040846664,
            0.0000035452649740387483,
            15865206,
            2459773,
            255
        );

        _mvxApiClient.Mex.GetMexEconomicsAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexEconomicsAsync();

        // assert
        result.TotalSupply.Should().Be(expectedResult.TotalSupply);
        result.CirculatingSupply.Should().Be(expectedResult.CirculatingSupply);
        result.Price.Should().Be(expectedResult.Price);
        result.MarketCap.Should().Be(expectedResult.MarketCap);
        result.Volume.Should().Be(expectedResult.Volume);
        result.MarketPairs.Should().Be(expectedResult.MarketPairs);
    }
    
    [Fact]
    public async Task GetMexPairsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
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

        _mvxApiClient.Mex.GetMexPairsAsync().Returns(Task.FromResult<IEnumerable<MexPairDto>>(expectedResult));
        
        // act
        var mexPairs = await _mvxApiClient.Mex.GetMexPairsAsync();
        var result = mexPairs.ToList();

        // assert
        result.Should().NotBeEmpty().And.HaveCount(2);
        result.Select(p => p.Address).Should().Equal(expectedResult.Select(p => p.Address));
        result.Select(p => p.Id).Should().Equal(expectedResult.Select(p => p.Id));
        result.Select(p => p.Symbol).Should().Equal(expectedResult.Select(p => p.Symbol));
        result.Select(p => p.Name).Should().Equal(expectedResult.Select(p => p.Name));
        result.Select(p => p.Price).Should().Equal(expectedResult.Select(p => p.Price));
        result.Select(p => p.BasePreviousPrice).Should().Equal(expectedResult.Select(p => p.BasePreviousPrice));
        result.Select(p => p.QuotePreviousPrice).Should().Equal(expectedResult.Select(p => p.QuotePreviousPrice));
        result.Select(p => p.BaseId).Should().Equal(expectedResult.Select(p => p.BaseId));
        result.Select(p => p.BaseSymbol).Should().Equal(expectedResult.Select(p => p.BaseSymbol));
        result.Select(p => p.BaseName).Should().Equal(expectedResult.Select(p => p.BaseName));
        result.Select(p => p.BasePrice).Should().Equal(expectedResult.Select(p => p.BasePrice));
        result.Select(p => p.QuoteId).Should().Equal(expectedResult.Select(p => p.QuoteId));
        result.Select(p => p.QuoteSymbol).Should().Equal(expectedResult.Select(p => p.QuoteSymbol));
        result.Select(p => p.QuoteName).Should().Equal(expectedResult.Select(p => p.QuoteName));
        result.Select(p => p.QuotePrice).Should().Equal(expectedResult.Select(p => p.QuotePrice));
        result.Select(p => p.TotalValue).Should().Equal(expectedResult.Select(p => p.TotalValue));
        result.Select(p => p.Volume).Should().Equal(expectedResult.Select(p => p.Volume));
        result.Select(p => p.State).Should().Equal(expectedResult.Select(p => p.State));
        result.Select(p => p.Type).Should().Equal(expectedResult.Select(p => p.Type));
        result.Select(p => p.Exchange).Should().Equal(expectedResult.Select(p => p.Exchange));
        result.Select(p => p.HasFarms).Should().Equal(expectedResult.Select(p => p.HasFarms));
        result.Select(p => p.HasDualFarms).Should().Equal(expectedResult.Select(p => p.HasDualFarms));
        result.Select(p => p.TradesCount).Should().Equal(expectedResult.Select(p => p.TradesCount));
        result.Select(p => p.PreviousTradesCount).Should().Equal(expectedResult.Select(p => p.PreviousTradesCount));
        result.Select(p => p.DeployedAt).Should().Equal(expectedResult.Select(p => p.DeployedAt));
    }
    
    [Fact]
    public async Task GetMexPairAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
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

        _mvxApiClient.Mex.GetMexPairAsync(baseId, quoteId).Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexPairAsync(baseId, quoteId);

        // assert
        result.Address.Should().Be(expectedResult.Address);
        result.Id.Should().Be(expectedResult.Id);
        result.Symbol.Should().Be(expectedResult.Symbol);
        result.Name.Should().Be(expectedResult.Name);
        result.Price.Should().Be(expectedResult.Price);
        result.BasePreviousPrice.Should().Be(expectedResult.BasePreviousPrice);
        result.QuotePreviousPrice.Should().Be(expectedResult.QuotePreviousPrice);
        result.BaseId.Should().Be(expectedResult.BaseId);
        result.BaseSymbol.Should().Be(expectedResult.BaseSymbol);
        result.BaseName.Should().Be(expectedResult.BaseName);
        result.BasePrice.Should().Be(expectedResult.BasePrice);
        result.QuoteId.Should().Be(expectedResult.QuoteId);
        result.QuoteSymbol.Should().Be(expectedResult.QuoteSymbol);
        result.QuoteName.Should().Be(expectedResult.QuoteName);
        result.QuotePrice.Should().Be(expectedResult.QuotePrice);
        result.TotalValue.Should().Be(expectedResult.TotalValue);
        result.Volume.Should().Be(expectedResult.Volume);
        result.State.Should().Be(expectedResult.State);
        result.Type.Should().Be(expectedResult.Type);
        result.Exchange.Should().Be(expectedResult.Exchange);
        result.HasFarms.Should().Be(expectedResult.HasFarms);
        result.HasDualFarms.Should().Be(expectedResult.HasDualFarms);
        result.TradesCount.Should().Be(expectedResult.TradesCount);
        result.PreviousTradesCount.Should().Be(expectedResult.PreviousTradesCount);
        result.DeployedAt.Should().Be(expectedResult.DeployedAt);
    }
    
    [Fact]
    public async Task GetMexPairsCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        const int expectedResult = 2;

        _mvxApiClient.Mex.GetMexPairsCountAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexPairsCountAsync();

        // assert
        result.Should().Be(expectedResult);
    }
    
    [Fact]
    public async Task GetMexTokensAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
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

        _mvxApiClient.Mex.GetMexTokensAsync().Returns(Task.FromResult<IEnumerable<MexTokenDto>>(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexEconomicsAsync();

        // assert
        
    }
    
    [Fact]
    public async Task GetMexTokenAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
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

        _mvxApiClient.Mex.GetMexTokenAsync(identifier).Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexTokenAsync(identifier);

        // assert
        result.Id.Should().Be(expectedResult.Id);
        result.Symbol.Should().Be(expectedResult.Symbol);
        result.Name.Should().Be(expectedResult.Name);
        result.Price.Should().Be(expectedResult.Price);
        result.PreviousPrice.Should().Be(expectedResult.PreviousPrice);
        result.PreviousVolume.Should().Be(expectedResult.PreviousVolume);
        result.TradesCount.Should().Be(expectedResult.TradesCount);
    }
    
    [Fact]
    public async Task GetMexTokensCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        const int expectedResult = 2;

        _mvxApiClient.Mex.GetMexTokensCountAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexTokensCountAsync();

        // assert
        result.Should().Be(expectedResult);
    }
    
    [Fact]
    public async Task GetMexFarmsAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
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

        _mvxApiClient.Mex.GetMexFarmsAsync().Returns(Task.FromResult<IEnumerable<MexFarmDto>>(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexFarmsAsync();

        // assert
        
    }
    
    [Fact]
    public async Task GetMexFarmsCountAsync_NoParameters_ReturnsExpectedRecord()
    {
        // arrange
        const int expectedResult = 2;

        _mvxApiClient.Mex.GetMexFarmsCountAsync().Returns(Task.FromResult(expectedResult));
        
        // act
        var result = await _mvxApiClient.Mex.GetMexFarmsCountAsync();

        // assert
        result.Should().Be(expectedResult);
    }
}
