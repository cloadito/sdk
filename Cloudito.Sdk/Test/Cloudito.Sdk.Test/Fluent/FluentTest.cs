using Cloudito.Sdk.Base.Fluent.Builder;
using Cloudito.Sdk.Base.Fluent.Provider;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

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
}