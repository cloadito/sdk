namespace Cloudito.Sdk;

public record User(Guid Id, string FirstName, string LastName, string MobileNo, string Email);

public record SetPassword(string UserName, string Code, string NewPassword, string ReNewPassword);

public record ForceRegisterRequest(string FirstName, string LastName, string MobileNo, string Email);