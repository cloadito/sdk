namespace Cloudito.Sdk;

public record LoginResult(User User, string Token, string RefreshToken);
