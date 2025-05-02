namespace Cloudito.Sdk;

internal class UrlsConst
{
    public const string V1 = "v1.0";

    public const string V1BaseUrl = $"/api/{V1}";

    public class Identity
    {
        public const string SendOtp = $"{V1BaseUrl}auth/send-otp";

        public const string LoginOtp = $"{V1BaseUrl}auth/login-otp";
    }

    public class Wallet
    {
        public static Func<Guid, string> Init = (Guid userId) => $"{V1BaseUrl}/wallet/init?userId={userId}";

        public static Func<Guid, string> GetUserWallet = (Guid userId) => $"{V1BaseUrl}/wallet/get-user-wallet?userId={userId}";

        public static Func<Guid, string> GetInventory = (Guid userId) => $"{V1BaseUrl}/wallet/get-inventory?userId={userId}";
    }

    public class Applicaitons
    {

    }

    public class Ticket
    {

    }
}