namespace Cloudito.Sdk;

internal partial class UrlsConst
{
    public class Identity
    {
        public const string SendOtp = $"{V1BaseUrl}/auth/send-otp";

        public const string LoginOtp = $"{V1BaseUrl}/auth/login-otp";

        public const string Login = $"{V1BaseUrl}/auth/login";

        public static readonly Func<Guid, string> GetProfile = (userId) =>
            $"{V1BaseUrl}/auth/get-profile?userId={userId}";

        public const string RefreshToken = $"{V1BaseUrl}/auth/refresh-token";

        public const string SetPassword = $"{V1BaseUrl}/auth/set-password";

        public const string SetProfile = $"{V1BaseUrl}/auth/set-profile";

        public const string GetRoles = $"{V1BaseUrl}/role/get-roles";

        public static readonly Func<Guid, string> FindUserById = (userId) => $"{V1BaseUrl}/user/find-by-id?id={userId}";

        public const string ForceRegister = $"{V1BaseUrl}/user/force-register";

        public const string HasAccess = $"{V1BaseUrl}/user/has-access";

        public static readonly Func<int, int, string> GetAppUsers = (page, count) =>
            $"{V1BaseUrl}/user/get-app-users?page={page}&count={count}";

        public static readonly Func<Guid, string> GetUserRoles = (userId) =>
            $"{V1BaseUrl}/user/get-user-roles?userId={userId}";

        public static readonly Func<Guid, string, string> IsInRole = (userId, role) =>
            $"{V1BaseUrl}/user/is-in-role?userId={userId}&role={role}";

        public static readonly Func<string, string> FindUserByUserName =
            (userName) => $"{V1BaseUrl}/user/find-by-user-name?userName={userName}";
    }
}