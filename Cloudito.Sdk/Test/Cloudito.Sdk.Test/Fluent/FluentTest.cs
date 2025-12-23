using System.Net;
using Cloudito.Sdk.Base.Fluent.Builder;
using Cloudito.Sdk.Base.Fluent.Provider;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using IBaseService = Cloudito.Sdk.Base.Fluent.Builder.IBaseService;

namespace Cloudito.Sdk.Test.Fluent;

public class FluentTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IBaseService _baseService = fixture.ServiceProvider.GetRequiredService<IBaseService>();

    private readonly IRestClientProvider _clientProvider =
        fixture.ServiceProvider.GetRequiredService<IRestClientProvider>();

    [Fact]
    public async Task BuilderTest()
    {
        var result = await _baseService.From("api/authentication/v1.0/login")
            .WithBody(new
            {
                UserName = "admin",
                Password = "123456",
            })
            .WithMethod(HttpMethod.Post)
            .ExecuteAsync<object>();

        outputHelper.WriteLine("Result: " + JsonConvert.SerializeObject(result));
        Assert.True(result != null);
    }

    [Fact]
    public async Task RestProviderTest()
    {
        var result = await _clientProvider.GetService("auth2")
            .From("api/authentication/v1.0/login")
            .WithBody(new
            {
                UserName = "admin",
                Password = "123456",
            })
            .WithMethod(HttpMethod.Post)
            .ExecuteAsync<object>();

        outputHelper.WriteLine("Result: " + JsonConvert.SerializeObject(result));
        Assert.True(result != null);
    }

    [Fact]
    public async Task BuildersTest()
    {
        var result = await _clientProvider.GetService("auth2")
            .From("api/authentication/v1.0/login")
            .WithBody(new
            {
                UserName = "admin",
                Password = "123456A",
            })
            .WithMethod(HttpMethod.Post)
            .ExecuteAsync<ApiSuccessResponse, ApiErrorResponse>();

        outputHelper.WriteLine("Result: " + JsonConvert.SerializeObject(result));
        Assert.True(result is not null);
    }
}

public record ApiErrorResponse(
    [property: JsonProperty("data")] ErrorData Data,
    [property: JsonProperty("isSuccess")] bool IsSuccess,
    [property: JsonProperty("message")] string Message
);

public record ErrorData(
    [property: JsonProperty("errorsList")] List<ErrorItem> ErrorsList
);

public record ErrorItem(
    [property: JsonProperty("errorCode")] int ErrorCode,
    [property: JsonProperty("errorDescription")]
    string ErrorDescription,
    [property: JsonProperty("referenceName")]
    string? ReferenceName,
    [property: JsonProperty("originalValue")]
    string? OriginalValue,
    [property: JsonProperty("extraData")] string? ExtraData
);

public record ApiSuccessResponse(
    [property: JsonProperty("data")] AuthData Data,
    [property: JsonProperty("isSuccess")] bool IsSuccess,
    [property: JsonProperty("message")] string Message
);

public record AuthData(
    [property: JsonProperty("token")] string Token,
    [property: JsonProperty("refreshToken")]
    string RefreshToken,
    [property: JsonProperty("refreshTokenExpiration")]
    int RefreshTokenExpiration,
    [property: JsonProperty("tokenExpiration")]
    int TokenExpiration,
    [property: JsonProperty("shopUser")] object? ShopUser
);