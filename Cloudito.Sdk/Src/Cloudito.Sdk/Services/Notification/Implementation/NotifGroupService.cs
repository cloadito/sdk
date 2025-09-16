namespace Cloudito.Sdk.Services;

public class NotifGroupService(IBaseService baseService) : INotifGroup
{
    public Task<ServiceResult<Pagination<NotifGroup>>> GetGroupsAsync(int page, int count,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Pagination<NotifGroup>>(UrlsConst.Notif.GetGroups(page, count), null,
            HttpMethod.Get, cancellationToken);

    public Task<ServiceResult<bool>> IsMemberAsync(Guid groupId, string memberId,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<bool>(UrlsConst.Notif.IsMember(groupId, memberId), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<object>> AddMemberAsync(UpdateMemberNotifGroupRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Notif.AddMember, request, HttpMethod.Post, cancellationToken);

    public Task<ServiceResult<object>> RemoveMemberAsync(UpdateMemberNotifGroupRequest request,
        CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync(UrlsConst.Notif.RemoveMember, request, HttpMethod.Post, cancellationToken);
}