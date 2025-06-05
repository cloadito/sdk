namespace Cloudito.Sdk.Services;

internal class Auth(IRest rest, IBaseService baseService) : IAuth
{
    public async Task<ServiceResult<User?>> GetProfileAsync(Guid userId)
        => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.GetProfile(userId), null, HttpMethod.Get);

    public async Task<ServiceResult<LoginResult>> LoginOtpAsync(string userName, string code)
    {
        try
        {
            ApiResult<LoginResult> request = await rest.PostAsync<LoginResult>(UrlsConst.Identity.LoginOtp, new
            {
                UserName = userName,
                Code = code
            });
            return ServiceResult<LoginResult>.FromApi(request);
        }
        catch (Exception ex)
        {
            return ServiceResult<LoginResult>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<object>> SendOtpAsync(string userName)
    {
        try
        {
            ApiResult<object> request = await rest.PostAsync<object>(UrlsConst.Identity.SendOtp, new
            {
                UserName = userName
            });
            return ServiceResult<object>.FromApi(request);
        }
        catch (Exception ex)
        {
            return ServiceResult<object>.Error(ex.Message);
        }
    }

    public async Task<ServiceResult<User?>> SetProfileAsync(SetProfile profile)
     => await baseService.CallServiceAsync<User?>(UrlsConst.Identity.SetProfile, profile, HttpMethod.Post);
}
