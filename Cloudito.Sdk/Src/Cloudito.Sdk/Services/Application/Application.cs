namespace Cloudito.Sdk.Services;

internal class Application(IBaseService baseService) : IApplication
{
    public async Task<ServiceResult<bool>> IsAdminAsync(Guid userId, Guid appId)
        => await baseService.CallServiceAsync<bool>(UrlsConst.Applicaitons.IsAdmin, new
        {
            AdminId = userId,
            AppId = appId,
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> MakeTransactionAsync(Guid appId, decimal amount)
         => await baseService.CallServiceAsync<object>(UrlsConst.Applicaitons.MakeTransaction, new
         {
             AppId = appId,
             Amount = amount,
         }, HttpMethod.Post);
}
