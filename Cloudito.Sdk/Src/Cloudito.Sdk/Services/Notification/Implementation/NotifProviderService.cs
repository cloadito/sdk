namespace Cloudito.Sdk.Services;

public class NotifProviderService(IBaseService baseService) : INotifProvider
{
    public Task<ServiceResult<NotifProvider>> GetByUniqAsync(string uniq, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<NotifProvider>(UrlsConst.Notif.GetProviderByUniq(uniq), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<Pagination<NotifProvider>>> GetListAsync(int page, int count,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<NotifProvider>>(UrlsConst.Notif.GetProviders(page, count), null,
            HttpMethod.Get,
            cancellationToken);
}