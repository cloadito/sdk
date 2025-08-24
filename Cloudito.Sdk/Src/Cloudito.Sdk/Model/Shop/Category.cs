namespace Cloudito.Sdk;

public record ProductCategory(Guid Id,Guid? ParentId,string Name,string? ShortDescription,string? Description);