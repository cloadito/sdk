namespace Cloudito.Sdk;

internal partial class UrlsConst
{
    public class Ticket
    {
        public const string GetDepartments = $"{V1BaseUrl}/department/get-list";

        public static readonly Func<Guid, Guid, string> DeleteMessage = (Guid ticketId, Guid messageId) =>
            $"{V1BaseUrl}/message/delete?ticketId={ticketId}&messageId={messageId}";

        public static readonly Func<Guid, int, int, string> GetMessages = (Guid ticketId, int page, int count) =>
            $"{V1BaseUrl}/message/get-list?ticketId={ticketId}&page={page}&count={count}";

        public const string UpsertMessage = "/ticket/message/upsert";

        public static readonly Func<Guid?, int, int, string> GetAppTickets =
            (Guid? departmentId, int page, int count) =>
                $"{V1BaseUrl}/get-app-tickets?{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public static readonly Func<Guid, Guid?, int, int, string> GetUserTickets =
            (Guid userId, Guid? departmentId, int page, int count) =>
                $"{V1BaseUrl}/get-user-tickets?userId={userId}&{(departmentId is null ? "" : $"departmentId={departmentId}&")}page={page}&count={count}";

        public const string New = $"{V1BaseUrl}/ticket/new";
    }
}