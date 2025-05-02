namespace Cloudito.Sdk.Services;

internal class Auth(IRest rest) : IAuth
{
    public async Task<ServiceResult<LoginResult>> LoginOtpAsync(string userName, string code)
    {
        try
        {
            ApiModel<LoginResult> request = await rest.PostAsync<LoginResult>(Constants.UrlsConst.LoginOtp, new
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
            ApiModel<object> request = await rest.PostAsync<object>(Constants.UrlsConst.SendOtp, new
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
}
