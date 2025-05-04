namespace Cloudito.Sdk.Services;

public interface IWallet
{
    Task<ServiceResult<Wallet?>> GetUserWalletAsync(Guid userId);

    Task<ServiceResult<WalletInventory?>> GetInventoryAsync(Guid userId);

    Task<ServiceResult<Wallet?>> InitAsync(Guid userId);

    /// <summary>
    /// Get wallet transactions list in pagination model
    /// </summary>
    /// <param name="walletId">Wallet id </param>
    /// <param name="page">start page that is zero index</param>
    /// <param name="count">page size</param>
    /// <returns><see cref="PaginationResult{TResult}"/> Of <see cref="WalletTransaction"/> </returns>
    Task<ServiceResult<PaginationResult<WalletTransaction>>> GetTransactionsAsync(Guid walletId, int page, int count);
}
