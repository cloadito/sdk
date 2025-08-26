namespace Cloudito.Sdk.Services;

internal class ApplicationService(IBaseService baseService) : IApplication
{
    public async Task<ServiceResult<bool>> IsAdminAsync(Guid userId, Guid appId)
        => await baseService.CallServiceAsync<bool>(UrlsConst.Applicaitons.IsAdmin, new
        {
            AdminId = userId,
            AppId = appId,
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> LogUsageAsync(IEnumerable<LogUsage> logs)
        => await baseService.CallServiceAsync<object>(UrlsConst.Applicaitons.LogUsage, new
        {
            Logs = logs
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> MakeBulkTransactionAsync(IEnumerable<MakeTransaction> transactions)
        => await baseService.CallServiceAsync<object>(UrlsConst.Applicaitons.MakeBulkTransaction, new
        {
            transactions = transactions,
        }, HttpMethod.Post);

    public async Task<ServiceResult<object>> MakeTransactionAsync(MakeTransaction transaction)
         => await baseService.CallServiceAsync<object>(UrlsConst.Applicaitons.MakeTransaction, transaction, HttpMethod.Post);

    public async Task<ServiceResult<object>> MakeTransactionAsync(Guid appId, decimal amount)
        => await MakeTransactionAsync(new(appId, amount));
}
