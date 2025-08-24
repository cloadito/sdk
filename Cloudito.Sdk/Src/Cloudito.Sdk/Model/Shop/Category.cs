namespace Cloudito.Sdk;

public record ProductCategory(Guid Id, Guid? ParentId, string Name, string? ShortDescription, string? Description);

public record AddCategoryToShop(Guid ShopId, Guid CategoryId);

public record GetCategories(
    Guid? ParentId,
    Guid? ShopTypeId,
    string? Q,
    CategoryAccessType? AccessType,
    int Page,
    int Count);

public enum CategoryAccessType
{
    Private,
    Public,
}

public record UpsertProductCategory(
    Guid? Id,
    Guid? ParentId,
    Guid? ShopTypeId,
    CategoryAccessType AccessType,
    string Name,
    string? ShortDescription,
    string? Description);