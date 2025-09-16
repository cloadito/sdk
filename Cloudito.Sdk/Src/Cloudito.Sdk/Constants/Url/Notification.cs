namespace Cloudito.Sdk;

internal partial class UrlsConst
{
    public class Notif
    {
        public static readonly Func<int, int, string> GetGroups = (page, count) =>
            $"{V1BaseUrl}/groups?page={page}&count={count}";

        public static readonly Func<Guid, string, string> IsMember = (groupId, memberId) =>
            $"{V1BaseUrl}/groups/is-member?groupId={groupId}&memberId={memberId}";

        public const string AddMember = $"{V1BaseUrl}/groups/add-member";

        public const string RemoveMember = $"{V1BaseUrl}/groups/remove-member";
    }
}