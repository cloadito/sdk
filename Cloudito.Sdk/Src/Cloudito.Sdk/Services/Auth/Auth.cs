namespace Cloudito.Sdk.Services;

internal class Auth(IBaseService baseService) : IAuth
{
    public async Task<ServiceResult<User?>> GetProfileAsync(Guid userId)
        => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.GetProfile(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<LoginResult>> LoginAsync(string userName, string password)
        => await baseService.CallServiceAsync<LoginResult>(UrlsConst.Identity.Login, new
        {
            UserName = userName,
            Password = password,
        }, HttpMethod.Post);

    public async Task<ServiceResult<LoginResult>> LoginOtpAsync(string userName, string code)
         => await baseService.CallServiceAsync<LoginResult>(UrlsConst.Identity.LoginOtp, new
         {
             UserName = userName,
             Code = code
         }, HttpMethod.Post);

    public async Task<ServiceResult<string>> RefreshTokenAsync(string token)
        => await baseService.CallServiceAsync<string>(UrlsConst.Identity.RefreshToken, new
        {
            Token = token
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> SendOtpAsync(string userName)
        => await baseService.CallServiceAsync<object>(UrlsConst.Identity.SendOtp, new
        {
            UserName = userName
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> SetPasswordAsync(SetPassword setPassword)
        => await baseService.CallServiceAsync<object>(UrlsConst.Identity.SetPassword, setPassword, HttpMethod.Post);

    public async Task<ServiceResult<User?>> SetProfileAsync(SetProfile profile)
     => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.SetProfile, profile, HttpMethod.Post);
}
