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
        public const string Init = $"{V1BaseUrl}/wallet/init";

        public const string GetUserWallet = $"{V1BaseUrl}/wallet/get-user-wallet";

        public const string GetInventory = $"{V1BaseUrl}/wallet/get-inventory";
    }
}