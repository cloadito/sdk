namespace Cloudito.Sdk;

public record ProductProperties(Guid Id, string Name, string Value);

public record ProductProperty(Guid Id, string Name);

/// <summary>
/// Upsert property model use when upsert product
/// </summary>
/// <param name="PropId">Property id <see cref="ProductProperty.Id"/></param>
/// <param name="Value">Property value</param>
public record UpsertProductProperties(Guid PropId,string Value);

public record UpsertProperty(Guid? Id,Guid CategoryId,string Name,string? Description);