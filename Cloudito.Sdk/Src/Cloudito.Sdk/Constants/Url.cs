namespace Cloudito.Sdk;

internal class UrlsConst
{
    public const string V1 = "v1.0";

    public const string V1BaseUrl = $"api/{V1}";

    public class Identity
    {
        public const string SendOtp = $"/auth/send-otp";

        public const string LoginOtp = $"/auth/login-otp";
    }

    public class Wallet
    {
        public static Func<Guid, string> Init = (Guid userId) => $"/wallet/init?userId={userId}";

        public static Func<Guid, string> GetUserWallet = (Guid userId) => $"/wallet/get-user-wallet?userId={userId}";

        public static Func<Guid, string> GetInventory = (Guid userId) => $"/wallet/get-inventory?userId={userId}";

        public static Func<Guid, int, int, string> GetWalletTransactions = (Guid walletId, int page, int count) => $"/wallet/transaction/get-transactions?walletId={walletId}&page={page}&count={count}";

        public const string UpsertTransaction = "/wallet/transaction/upsert";

        public const string GetAppWallet = "/wallet/get-app-wallet";
    }

    public class Applicaitons
    {

    }

    public class Ticket
    {

    }
}