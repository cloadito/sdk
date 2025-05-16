using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class ApplicationTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IApplication _app = fixture.ServiceProvider.GetRequiredService<IApplication>();

    [Fact]
    public async Task IsAdmin()
    {
        var isAdmin = await _app.IsAdminAsync(Constants.adminId, Constants.appId);

        if (!isAdmin.Success)
        {
            Assert.Fail(isAdmin.Message);
            return;
        }

        Assert.True(isAdmin.Success);
        outputHelper.WriteLine(isAdmin.Message);
        outputHelper.WriteLine(isAdmin.Result.ToString());
    }

    [Fact]
    public async Task MakeTransaction()
    {
        var transaction = await _app.MakeTransactionAsync(Constants.appId, 1000);

        if (!transaction.Success)
        {
            Assert.Fail(transaction.Message);
            return;
        }

        Assert.True(transaction.Success);
        outputHelper.WriteLine(transaction.Message);
        outputHelper.WriteLine(transaction.Result?.ToString());
    }
}
