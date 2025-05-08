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

        public static Func<string, Guid, string> FindTransactionByUniqId = (string uniqId, Guid walletId) => $"/wallet/transaction/find-by-uniqid?uniqId={uniqId}&walletId={walletId}";

        public const string UpsertTransaction = "/wallet/transaction/upsert";

        public const string TransferToAppWallet = "/wallet/transaction/transfer-to-app-wallet";

        public const string GetAppWallet = "/wallet/get-app-wallet";
    }

    public class Applicaitons
    {

    }

    public class Ticket
    {
        public const string GetDepartmetns = "/ticket/department/get-list";

        public static Func<Guid, Guid, string> DeleteMessage = (Guid ticketId, Guid messageId) => $"/ticket/message/delete?ticketId={ticketId}&messageId={messageId}";

        public static Func<Guid, int, int, string> GetMessages = (Guid ticketId, int page, int count) => $"/ticket/message/get-list?ticketId={ticketId}&page={page}&count={count}";

        public const string UpsertMessage = "/ticket/message/upsert";

        public static Func<Guid?, int, int, string> GetAppTickets = (Guid? departmentId, int page, int count) => $"/ticket/get-app-tickets?{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public static Func<Guid, Guid?, int, int, string> GetUserTickets = (Guid userId, Guid? departmentId, int page, int count) => $"/ticket/get-user-tickets?userId={userId}&{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public const string New = "/ticket/new";
    }
}