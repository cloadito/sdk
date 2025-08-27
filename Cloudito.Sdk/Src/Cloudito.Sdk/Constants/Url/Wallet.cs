namespace Cloudito.Sdk;

internal partial class UrlsConst
{
    public class Wallet
    {
        public static readonly Func<Guid, string> Init = (Guid userId) => $"{V1BaseUrl}/wallet/init?userId={userId}";

        public static readonly Func<Guid, string> GetUserWallet =
            (Guid userId) => $"{V1BaseUrl}/wallet/get-user-wallet?userId={userId}";

        public static readonly Func<Guid, string> GetInventory = (Guid userId) =>
            $"{V1BaseUrl}/wallet/get-inventory?userId={userId}";


        public static readonly Func<Guid, int, int, string> GetWalletTransactions =
            (Guid walletId, int page, int count) =>
                $"{V1BaseUrl}/transaction/get-transactions?walletId={walletId}&page={page}&count={count}";

        public static readonly Func<string, Guid, string> FindTransactionByUniqId = (string uniqId, Guid walletId) =>
            $"{V1BaseUrl}/transaction/find-by-uniqid?uniqId={uniqId}&walletId={walletId}";

        public const string UpsertTransaction = $"{V1BaseUrl}/transaction/upsert";

        public const string TransferToAppWallet = $"{V1BaseUrl}/transaction/transfer-to-app-wallet";

        public const string GetAppWallet = $"{V1BaseUrl}/wallet/get-app-wallet";
    }
}