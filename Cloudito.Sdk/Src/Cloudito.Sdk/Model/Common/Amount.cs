namespace Cloudito.Sdk;

public record Amount(string Currency,decimal Value);

public record NamedAmount(string Name,Amount Amount);