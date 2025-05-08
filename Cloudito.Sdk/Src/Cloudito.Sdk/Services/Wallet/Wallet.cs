namespace Cloudito.Sdk.Services;

internal class WalletService(IBaseService baseService) : IWallet
{
    public async Task<ServiceResult<WalletTransaction?>> FindByUniqIdAsync(string uniqId, Guid walletId)
        => await baseService.CallServiceAsync<WalletTransaction?>(UrlsConst.Wallet.FindTransactionByUniqId(uniqId, walletId), null, HttpMethod.Get);

    public async Task<ServiceResult<AppWallet?>> GetAppWalletAsync()
    => await baseService.CallServiceAsync<AppWallet?>(UrlsConst.Wallet.GetAppWallet, null, HttpMethod.Get);

    public async Task<ServiceResult<WalletInventory?>> GetInventoryAsync(Guid userId)
        => await baseService.CallServiceAsync<WalletInventory?>(UrlsConst.Wallet.GetInventory(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<Pagination<WalletTransaction>>> GetTransactionsAsync(Guid walletId, int page, int count)
        => await baseService.CallServiceAsync<Pagination<WalletTransaction>>(UrlsConst.Wallet.GetWalletTransactions(walletId, page, count), null, HttpMethod.Get);

    public async Task<ServiceResult<Wallet?>> GetUserWalletAsync(Guid userId)
        => await baseService.CallServiceAsync<Wallet?>(UrlsConst.Wallet.GetUserWallet(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<Wallet?>> InitAsync(Guid userId)
        => await baseService.CallServiceAsync<Wallet?>(UrlsConst.Wallet.Init(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<WalletTransaction?>> TransferToAppWalletAsync(Guid? transactionId, Guid walletId, decimal amount, TransactionStatus status)
        => await baseService.CallServiceAsync<WalletTransaction?>(UrlsConst.Wallet.TransferToAppWallet, new
        {
            transactionId,
            walletId,
            amount,
            Status = (byte)status,
        }, HttpMethod.Post);

    public async Task<ServiceResult<WalletTransaction>> UpsertTransactionAsync(WalletTransaction transaction)
        => await baseService.CallServiceAsync<WalletTransaction>(UrlsConst.Wallet.UpsertTransaction, transaction, HttpMethod.Post);

}
