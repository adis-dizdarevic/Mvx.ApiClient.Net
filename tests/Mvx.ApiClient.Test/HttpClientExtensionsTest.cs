using Mvx.ApiClient.Dtos;
using Mvx.ApiClient.ExtensionMethods;

namespace Mvx.ApiClient.Test;

public class HttpClientExtensionsTest
{
    private const string RequestUri = "https://api.multiversx.com/";
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoIsNull_UseDefaultValues()
    {
        // arrange

        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri);
        
        // assert
        Assert.Equal(RequestUri, result);
    }

    [Fact]
    public void BuildRequestUri_QueryParametersDtoNewInstanceWithoutSettingsValues_UseDefaultValues()
    {
        // arrange
        var data = new DataSelectionDto();
        
        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });
        
        // assert
        Assert.Equal(RequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoWithLimitAndOffset_ReturnsExpectedUri()
    {
        // arrange
        const string expectedRequestUri = $"{RequestUri}/?size=15&from=0";
        var pagination = new PaginationParametersDto { Limit = 15, Offset = 0 };

        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Pagination = pagination });

        // assert
        Assert.Equal(expectedRequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoWithOneField_ReturnsExpectedUri()
    {
        // arrange
        const string expectedRequestUri = $"{RequestUri}/?fields=balance";
        var data = new DataSelectionDto { Fields = ["balance"] };
        
        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });

        // assert
        Assert.Equal(expectedRequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoWithThreeFields_ReturnsExpectedUri()
    {
        // arrange
        const string expectedRequestUri = $"{RequestUri}/?fields=balance,address,price";
        var data = new DataSelectionDto { Fields = ["balance", "address", "price"] };

        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });

        // assert
        Assert.Equal(expectedRequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoWithScalarValue_ReturnsExpectedUri()
    {
        // arrange
        const string expectedRequestUri = $"{RequestUri}/?extract=price";
        var data = new DataSelectionDto { Extract = "price" };
        
        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });
        
        // assert
        Assert.Equal(expectedRequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_QueryParametersDtoWithAllPropertiesSet_ReturnsExpectedUri()
    {
        // arrange
        const string expectedRequestUri = $"{RequestUri}/?size=100&from=25&fields=balance,address,price&extract=amount";
        var dto = new QueryParametersDto
        {
            Pagination = new PaginationParametersDto { Limit = 100, Offset = 25 },
            Data = new DataSelectionDto { Fields = ["balance", "address", "price"], Extract = "amount" }
        };

        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, dto);

        // assert
        Assert.Equal(expectedRequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_EmptyFieldsList_DoesNotAddFieldsToUri()
    {
        // arrange
        var data = new DataSelectionDto  { Fields = [] };
        
        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });
        
        // assert
        Assert.Equal(RequestUri, result);
    }
    
    [Fact]
    public void BuildRequestUri_EmptyExtractString_DoesNotAddExtractToUri()
    {
        // arrange
        var data = new DataSelectionDto  { Extract = "" };
        
        // act
        var result = HttpClientExtensions.BuildRequestUri(RequestUri, new QueryParametersDto { Data = data });
        
        // assert
        Assert.Equal(RequestUri, result);
    }
}
