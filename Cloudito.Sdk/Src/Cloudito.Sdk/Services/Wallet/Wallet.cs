namespace Cloudito.Sdk.Services;

internal class WalletService(IRest rest) : IWallet
{
    public Task<ApiModel<WalletInventory?>> GetInventoryAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiModel<Wallet?>> GetUserWalletAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiModel<Wallet?>> InitAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
