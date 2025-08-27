using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class WalletTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IWallet _wallet = fixture.ServiceProvider.GetRequiredService<IWallet>();

    [Fact]
    public async Task InitWallet()
    {
        var initWallet = await _wallet.InitAsync(Constants.userId);
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
        var wallet = await _wallet.GetUserWalletAsync(Constants.userId);

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
        var wallet = await _wallet.GetInventoryAsync(Constants.userId);

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
    public async Task GetTransactions()
    {

        var transactions = await _wallet.GetTransactionsAsync((Guid)Constants.walletId, 0, 10);
        if (!transactions.Success)
        {
            Assert.Fail(transactions.Message);
            return;
        }

        Assert.True(transactions.Success);
        outputHelper.WriteLine(transactions.Message);
        outputHelper.WriteLine(transactions.ToString());
    }

    [Fact]
    public async Task UpsertTransaction()
    {
        var upsert = await _wallet.UpsertTransactionAsync(new(null, Constants.walletId, Guid.NewGuid().ToString(), 100000, TransactionType.Increment, TransactionStatus.Complete,
            new(null, "Charge Wallet", [new("Authority", "res.Authority")])));
        if (!upsert.Success)
        {
            Assert.Fail(upsert.Message);
            return;
        }

        Assert.True(upsert.Success);
        outputHelper.WriteLine(upsert.Message);
        outputHelper.WriteLine(upsert.ToString());
    }

    [Fact]
    public async Task FindByUniqId()
    {
        var find = await _wallet.FindByUniqIdAsync("57e39e8e-e8bb-4257-8a4c-cbb07b715789", Constants.walletId);
        if (!find.Success)
        {
            Assert.Fail(find.Message);
            return;
        }

        Assert.True(find.Success);
        outputHelper.WriteLine(find.Message);
        outputHelper.WriteLine(find.ToString());
    }

    [Fact]
    public async Task TransferToAppWallet()
    {
        var transfer = await _wallet.TransferToAppWalletAsync(null, Constants.walletId, 10000, TransactionStatus.Complete);
        if (!transfer.Success)
        {
            Assert.Fail(transfer.Message);
            return;
        }

        Assert.True(transfer.Success);
        outputHelper.WriteLine(transfer.Message);
        outputHelper.WriteLine(transfer.ToString());
    }

    [Fact]
    public async Task GetAppWallet()
    {
        var wallet = await _wallet.GetAppWalletAsync();
        if (!wallet.Success)
        {
            Assert.Fail(wallet.Message);
            return;
        }

        Assert.True(wallet.Success);
        outputHelper.WriteLine(wallet.Message);
        outputHelper.WriteLine(wallet.ToString());
    }
}
