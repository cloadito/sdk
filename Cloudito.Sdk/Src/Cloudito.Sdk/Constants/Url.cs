namespace Cloudito.Sdk;

internal class UrlsConst
{
    public class Identity
    {
        public const string _BaseUrl = "/api/v1.0/";

        public const string SendOtp = $"{_BaseUrl}auth/send-otp";

        public const string LoginOtp = $"{_BaseUrl}auth/login-otp";
    }
}