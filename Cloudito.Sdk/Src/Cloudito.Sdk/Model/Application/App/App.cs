namespace Cloudito.Sdk;

public record Application(Guid Id, string Name);

public record MakeTransaction(Guid AppId, decimal Amount);

public record LogUsage(Guid? AppId, string Endpoint, DateTime Datetime);