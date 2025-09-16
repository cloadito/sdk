namespace Cloudito.Sdk.Services;

public interface INotifGroup
{
    Task<ServiceResult<Pagination<NotifGroup>>> GetGroupsAsync(int page, int count,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<bool>> IsMemberAsync(Guid groupId, string memberId,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> AddMemberAsync(UpdateMemberNotifGroupRequest request,
        CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> RemoveMemberAsync(UpdateMemberNotifGroupRequest request,
        CancellationToken cancellationToken = default);
}