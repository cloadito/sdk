namespace Cloudito.Sdk;

public record NotifGroup(Guid Id, string Name, string? Description, int UsersCount);

public record UpdateMemberNotifGroupRequest(Guid GroupId,IEnumerable<string> MembersId);