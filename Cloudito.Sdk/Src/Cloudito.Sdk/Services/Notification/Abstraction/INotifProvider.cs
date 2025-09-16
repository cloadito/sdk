namespace Cloudito.Sdk.Services;

public interface INotifProvider
{
    Task<ServiceResult<NotifProvider>> GetByUniqAsync(string uniq, CancellationToken cancellationToken = default);

    Task<ServiceResult<Pagination<NotifProvider>>> GetListAsync(int page, int count,
        CancellationToken cancellationToken = default);
}