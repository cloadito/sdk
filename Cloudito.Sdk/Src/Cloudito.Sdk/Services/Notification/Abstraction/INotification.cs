namespace Cloudito.Sdk.Services;

public interface INotification
{
    Task<ServiceResult<Pagination<Notification>>> GetListAsync(GetNotificationsRequest request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<Notification>> SendAsync(SendNotificationRequest request,
        CancellationToken cancellationToken = default);
}