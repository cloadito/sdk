using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class WalletTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IWallet _wallet = fixture.ServiceProvider.GetRequiredService<IWallet>();

    private Guid _userId = Guid.Parse("bb0945d6-8172-4cd4-9db7-d80376bd9711");

    [Fact]
    public async Task InitWallet()
    {
        var initWallet = await _wallet.InitAsync(_userId);
        if (!initWallet.Success)
        {
            Assert.Fail(initWallet.Message);
            return;
        }

        Assert.True(initWallet.Success);
        outputHelper.WriteLine(initWallet.Message);
        outputHelper.WriteLine(initWallet.Result?.ToString());
    }

    [Fact]
    public async Task GetWallet()
    {
        var wallet = await _wallet.GetUserWalletAsync(_userId);

        if (!wallet.Success)
        {
            Assert.Fail(wallet.Message);
            return;
        }

        Assert.True(wallet.Success);
        outputHelper.WriteLine(wallet.Message);
        outputHelper.WriteLine(wallet.Result?.ToString());
    }

    [Fact]
    public async Task GetWalletInventory()
    {
        var wallet = await _wallet.GetInventoryAsync(_userId);

        if (!wallet.Success)
        {
            Assert.Fail(wallet.Message);
            return;
        }

        Assert.True(wallet.Success);
        outputHelper.WriteLine(wallet.Message);
        outputHelper.WriteLine(wallet.Result?.ToString());
    }
}
