namespace Cloudito.Sdk;

public record Notification(Guid Id, Guid ProviderId, string? Title, string? Text, NotificationStaus Status);

/// <summary>
/// Get Notifications list request model
/// </summary>
/// <param name="ForId">Filter by member id</param>
/// <param name="Uniq">Filter by provider uniq</param>
/// <param name="Page">Pagination page</param>
/// <param name="Count">Pagination page size</param>
public record GetNotificationsRequest(string? ForId, string? Uniq, int Page, int Count);

/// <summary>
/// Send notification request model
/// </summary>
/// <param name="Uniq">Provider uniq</param>
/// <param name="Title">Notif title</param>
/// <param name="Text">Notif text</param>
/// <param name="ForId">Send to member </param>
/// <param name="Groups">Send to groups</param>
/// <param name="Variables">Variables that set in panel</param>
public record SendNotificationRequest(
    string Uniq,
    string? Title,
    string? Text,
    string? ForId,
    IEnumerable<string> Groups,
    IDictionary<string, string> Variables);

public enum NotificationStaus
{
    Send,
    Read,
    Failed,
}