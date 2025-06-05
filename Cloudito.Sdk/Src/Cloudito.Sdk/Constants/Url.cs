namespace Cloudito.Sdk;

internal class UrlsConst
{
    public const string V1 = "v1.0";

    public const string V1BaseUrl = $"/api/{V1}";

    public class Identity
    {
        public const string SendOtp = $"{V1BaseUrl}/auth/send-otp";

        public const string LoginOtp = $"{V1BaseUrl}/auth/login-otp";

        public const string Login = $"{V1BaseUrl}/auth/login";

        public static Func<Guid, string> GetProfile = (userId) => $"{V1BaseUrl}/auth/get-profile?userId={userId}";

        public const string RefreshToken = $"{V1BaseUrl}/auth/refresh-token";

        public const string SetPassword = $"{V1BaseUrl}/auth/set-password";

        public const string SetProfile = $"{V1BaseUrl}/auth/set-profile";

        public const string GetRoles = $"{V1BaseUrl}/role/get-roles";

        public static Func<Guid, string> FindUserById = (userId) => $"{V1BaseUrl}/user/find-by-id?id={userId}";

        public const string ForceRegister = $"{V1BaseUrl}/user/force-register";

        public const string HasAccess = $"{V1BaseUrl}/user/has-access";

        public static Func<int, int, string> GetAppUsers = (page, count) => $"{V1BaseUrl}/user/get-app-users?page={page}&count={count}";

        public static Func<Guid, string> GetUserRoles = (userId) => $"{V1BaseUrl}/user/get-user-roles?userId={userId}";

        public static Func<Guid, string, string> IsInRole = (userId, role) => $"{V1BaseUrl}/user/is-in-role?userId={userId}&role={role}";

    }

    public class Wallet
    {
        public static Func<Guid, string> Init = (Guid userId) => $"{V1BaseUrl}/wallet/init?userId={userId}";

        public static Func<Guid, string> GetUserWallet = (Guid userId) => $"{V1BaseUrl}/wallet/get-user-wallet?userId={userId}";

        public static Func<Guid, string> GetInventory = (Guid userId) => $"{V1BaseUrl}/wallet/get-inventory?userId={userId}";


        public static Func<Guid, int, int, string> GetWalletTransactions = (Guid walletId, int page, int count) => $"{V1BaseUrl}/transaction/get-transactions?walletId={walletId}&page={page}&count={count}";

        public static Func<string, Guid, string> FindTransactionByUniqId = (string uniqId, Guid walletId) => $"{V1BaseUrl}/transaction/find-by-uniqid?uniqId={uniqId}&walletId={walletId}";

        public const string UpsertTransaction = $"{V1BaseUrl}/wallet/transaction/upsert";

        public const string TransferToAppWallet = $"{V1BaseUrl}/wallet/transaction/transfer-to-app-wallet";

        public const string GetAppWallet = $"{V1BaseUrl}/wallet/get-app-wallet";
    }

    public class Applicaitons
    {
        public const string IsAdmin = $"{V1BaseUrl}/application/is-admin";

        public const string MakeTransaction = $"{V1BaseUrl}/application/make-transaction";
    }

    public class Ticket
    {
        public const string GetDepartmetns = $"{V1BaseUrl}/department/get-list";

        public static Func<Guid, Guid, string> DeleteMessage = (Guid ticketId, Guid messageId) => $"{V1BaseUrl}/message/delete?ticketId={ticketId}&messageId={messageId}";

        public static Func<Guid, int, int, string> GetMessages = (Guid ticketId, int page, int count) => $"{V1BaseUrl}/message/get-list?ticketId={ticketId}&page={page}&count={count}";

        public const string UpsertMessage = "/ticket/message/upsert";

        public static Func<Guid?, int, int, string> GetAppTickets = (Guid? departmentId, int page, int count) => $"{V1BaseUrl}/get-app-tickets?{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public static Func<Guid, Guid?, int, int, string> GetUserTickets = (Guid userId, Guid? departmentId, int page, int count) => $"{V1BaseUrl}/get-user-tickets?userId={userId}&{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public const string New = $"{V1BaseUrl}/ticket/new";
    }
}