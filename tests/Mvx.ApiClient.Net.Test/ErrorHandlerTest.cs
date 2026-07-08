using System.Net;
using Mvx.ApiClient.Net.Exceptions;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public class ErrorHandlerTest
{
    [Test]
    public async Task SendAsync_JsonApiError_ThrowsMvxApiExceptionWithDetails()
    {
        // arrange
        using var client = CreateClient(TestHttpMessageHandler.JsonResponse("""
            {
              "message": "Token not found",
              "error": "Not Found",
              "statusCode": 404
            }
            """, HttpStatusCode.NotFound));

        // act
        var exception = await CaptureException(() => client.GetAsync("/missing-token"));

        // assert
        await Assert.That(exception.Message).IsEqualTo("Token not found");
        await Assert.That(exception.Error).IsEqualTo("Not Found");
        await Assert.That(exception.StatusCode).IsEqualTo(HttpStatusCode.NotFound);
        await Assert.That(exception.RequestMethod).IsEqualTo(HttpMethod.Get);
        await Assert.That(exception.RequestUri).IsEqualTo(new Uri("https://api.multiversx.com/missing-token"));
        await Assert.That(exception.ResponseContent).IsNotNull();
    }

    [Test]
    public async Task SendAsync_EmptyErrorBody_ThrowsMvxApiExceptionWithFallbackDetails()
    {
        // arrange
        using var client = CreateClient(new HttpResponseMessage(HttpStatusCode.TooManyRequests));

        // act
        var exception = await CaptureException(() => client.GetAsync("/rate-limited"));

        // assert
        await Assert.That(exception.Message).IsEqualTo("MultiversX API request failed with status code 429 (TooManyRequests).");
        await Assert.That(exception.Error).IsEqualTo("Too Many Requests");
        await Assert.That(exception.StatusCode).IsEqualTo(HttpStatusCode.TooManyRequests);
        await Assert.That(exception.ResponseContent).IsNull();
    }

    [Test]
    public async Task SendAsync_NonJsonErrorBody_ThrowsMvxApiExceptionWithResponseContent()
    {
        // arrange
        using var client = CreateClient(TestHttpMessageHandler.TextResponse("upstream unavailable", HttpStatusCode.BadGateway));

        // act
        var exception = await CaptureException(() => client.GetAsync("/gateway-error"));

        // assert
        await Assert.That(exception.Message).IsEqualTo("MultiversX API request failed with status code 502 (BadGateway). Response content: upstream unavailable");
        await Assert.That(exception.Error).IsEqualTo("Bad Gateway");
        await Assert.That(exception.StatusCode).IsEqualTo(HttpStatusCode.BadGateway);
        await Assert.That(exception.ResponseContent).IsEqualTo("upstream unavailable");
    }

    private static HttpClient CreateClient(HttpResponseMessage response)
    {
        var innerHandler = new TestHttpMessageHandler(_ => response);
        var errorHandler = new ServiceCollectionExtensions.ErrorHandler
        {
            InnerHandler = innerHandler
        };

        return new HttpClient(errorHandler)
        {
            BaseAddress = new Uri("https://api.multiversx.com")
        };
    }

    private static async Task<MvxApiException> CaptureException(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (MvxApiException exception)
        {
            return exception;
        }

        throw new InvalidOperationException("Expected MvxApiException was not thrown.");
    }
}
