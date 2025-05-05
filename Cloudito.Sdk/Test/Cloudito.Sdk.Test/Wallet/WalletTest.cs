using Cloudito.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Cloudito.Sdk.Test;

public class WalletTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IWallet _wallet = fixture.ServiceProvider.GetRequiredService<IWallet>();

    private Guid _userId = Guid.Parse("bb0945d6-8172-4cd4-9db7-d80376bd9711");
    private Guid _walletId = Guid.Parse("a90d5b73-b516-4901-8cf1-a999db468932");

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

    [Fact]
    public async Task GetTransactions()
    {

        ServiceResult<PaginationResult<WalletTransaction>> transactions = await _wallet.GetTransactionsAsync((Guid)_walletId, 0, 10);
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
        var upsert = await _wallet.UpsertTransactionAsync(new(null, _walletId, Guid.NewGuid().ToString(), 100000, TransactionType.Increment, TransactionStatus.Complete, null));
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
        var find = await _wallet.FindByUniqIdAsync("57e39e8e-e8bb-4257-8a4c-cbb07b715789", _walletId);
        if (!find.Success)
        {
            Assert.Fail(find.Message);
            return;
        }

        Assert.True(find.Success);
        outputHelper.WriteLine(find.Message);
        outputHelper.WriteLine(find.ToString());
    }
}
