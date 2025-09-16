namespace Cloudito.Sdk;

public record NotifProvider(
    Guid Id,
    Guid AppId,
    NotifProviderType Type,
    string Uniq,
    string Name,
    NotifSmsProvider? SmsProvider);

public record NotifSmsProvider(
    IDictionary<string, string> Headers,
    IDictionary<string, dynamic> Body,
    string Url,
    string Method);

public enum NotifProviderType
{
    Email,
    Sms,
    InApp,
}