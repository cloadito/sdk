namespace Cloudito.Sdk.Services;

internal class WalletService(IRest rest) : IWallet
{
    public async Task<ServiceResult<WalletTransaction?>> FindByUniqIdAsync(string uniqId, Guid walletId)
    {
        try
        {
            ApiModel<WalletTransaction?> transactions = await rest.GetAsync<WalletTransaction?>(UrlsConst.Wallet.FindTransactionByUniqId(uniqId));
            return ServiceResult<WalletTransaction?>.FromApi(transactions);
        }
        catch (Exception ex)
        {
            return ServiceResult<WalletTransaction?>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<WalletInventory?>> GetInventoryAsync(Guid userId)
    {
        try
        {
            ApiModel<WalletInventory?> wallet = await rest.GetAsync<WalletInventory?>(UrlsConst.Wallet.GetInventory(userId));
            return ServiceResult<WalletInventory?>.FromApi(wallet);
        }
        catch (Exception ex)
        {
            return ServiceResult<WalletInventory?>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<PaginationResult<WalletTransaction>>> GetTransactionsAsync(Guid walletId, int page, int count)
    {
        try
        {
            ApiModel<PaginationResult<WalletTransaction>> transactions = await rest.GetAsync<PaginationResult<WalletTransaction>>(UrlsConst.Wallet.GetWalletTransactions(walletId, page, count));
            return ServiceResult<PaginationResult<WalletTransaction>>.FromApi(transactions);
        }
        catch (Exception ex)
        {
            return ServiceResult<PaginationResult<WalletTransaction>>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<Wallet?>> GetUserWalletAsync(Guid userId)
    {
        try
        {
            ApiModel<Wallet?> wallet = await rest.GetAsync<Wallet?>(UrlsConst.Wallet.GetUserWallet(userId));
            return ServiceResult<Wallet?>.FromApi(wallet);
        }
        catch (Exception ex)
        {
            return ServiceResult<Wallet?>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<Wallet?>> InitAsync(Guid userId)
    {
        try
        {
            ApiModel<Wallet?> wallet = await rest.GetAsync<Wallet?>(UrlsConst.Wallet.Init(userId));
            return ServiceResult<Wallet?>.FromApi(wallet);
        }
        catch (Exception ex)
        {
            return ServiceResult<Wallet?>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<WalletTransaction>> UpsertTransactionAsync(WalletTransaction transaction)
    {
        try
        {
            ApiModel<WalletTransaction> upsert = await rest.PostAsync<WalletTransaction>(UrlsConst.Wallet.UpsertTransaction, transaction);
            return ServiceResult<WalletTransaction>.FromApi(upsert);
        }
        catch (Exception ex)
        {
            return ServiceResult<WalletTransaction>.Error(ex.Message);
        }
    }
}
