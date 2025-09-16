namespace Cloudito.Sdk.Services;

public class NotificationService(IBaseService baseService) : INotification
{
    public Task<ServiceResult<Pagination<Notification>>> GetListAsync(GetNotificationsRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<Notification>>(UrlsConst.Notif.GetNotifList, request,
            HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<Notification>> SendAsync(SendNotificationRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Notification>(UrlsConst.Notif.SendNotif, request,
            HttpMethod.Post, cancellationToken);
}