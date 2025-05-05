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

    /// <summary>
    /// Upsert transaction
    /// </summary>
    /// <param name="transaction">Instance of <see cref="WalletTransaction"/> if want insert new item id of instance most be null and for update set id of item you want update id</param>
    /// <returns>Instance of <see cref="WalletTransaction"/></returns>
    Task<ServiceResult<WalletTransaction>> UpsertTransactionAsync(WalletTransaction transaction);

    Task<ServiceResult<WalletTransaction?>> FindByUniqIdAsync(string uniqId, Guid walletId);

    /// <summary>
    /// Transfer from wallet to app wallet
    /// </summary>
    /// <param name="transactionId">if wanna update transaction fill this</param>
    /// <param name="walletId">id of source wallet</param>
    /// <param name="amount">transaction amount</param>
    /// <param name="status">transaction status</param>
    /// <returns>Instance of <see cref="WalletTransaction"/></returns>
    Task<ServiceResult<WalletTransaction?>> TransferToAppWalletAsync(Guid? transactionId, Guid walletId, decimal amount, TransactionStatus status);
}
