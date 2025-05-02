namespace Cloudito.Sdk.Services;

public interface IWallet
{
    Task<ApiModel<Wallet?>> GetUserWalletAsync(Guid userId);

    Task<ApiModel<WalletInventory?>> GetInventoryAsync(Guid userId);

    Task<ApiModel<Wallet?>> InitAsync(Guid userId);
}
