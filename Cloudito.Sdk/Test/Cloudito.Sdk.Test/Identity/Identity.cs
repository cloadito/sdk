using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class IdentityTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IAuth _auth = fixture.ServiceProvider.GetRequiredService<IAuth>();

    [Fact]
    public async Task SendOtp()
    {
        var send = await _auth.SendOtpAsync("09012421080");
        if (!send.Success)
        {
            Assert.Fail(send.Message);
            return;
        }

        Assert.True(send.Success);
        outputHelper.WriteLine(send.Message);
        outputHelper.WriteLine(send.Result?.ToString());
    }

    [Fact]
    public async Task LoginOtp()
    {
        var login = await _auth.LoginOtpAsync("09012421080", "16229");
        if (!login.Success)
        {
            Assert.Fail(login.Message);
            return;
        }

        Assert.True(login.Success);
        outputHelper.WriteLine(login.Message);
        outputHelper.WriteLine(login.Result?.ToString());
    }
}
