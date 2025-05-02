namespace Cloudito.Sdk.Services;

public interface IWallet
{
    Task<ServiceResult<Wallet?>> GetUserWalletAsync(Guid userId);

    Task<ServiceResult<WalletInventory?>> GetInventoryAsync(Guid userId);

    Task<ServiceResult<Wallet?>> InitAsync(Guid userId);
}
