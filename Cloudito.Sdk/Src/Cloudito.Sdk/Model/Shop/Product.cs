namespace Cloudito.Sdk;

public record Product(
    Guid Id,
    string Name,
    string Title,
    string? ShortDescription,
    string? Description,
    ShopImage? Image,
    decimal? Amount);

public record ShopImage(Guid? FileId, string? Url);

public record AddProductToShop(Guid ShopId, Guid ProductId, byte Status, decimal? Amount, decimal? Inventory);

/// <summary>
/// Get products list request model
/// </summary>
/// <param name="ShopId">Filter products by shop id</param>
/// <param name="CategoryId">Filter products by category id</param>
/// <param name="Q">Filter products by search</param>
/// <param name="Page">Pagination page</param>
/// <param name="Count">Pagination page size</param>
public record GetProductsList(Guid? ShopId, Guid? CategoryId, string? Q, int Page, int Count);

public record ProductDetails(
    Guid Id,
    string Name,
    string Title,
    string? ShortDescription,
    string? Description,
    ShopImage? Image,
    int SellersCount,
    decimal Amount,
    IEnumerable<ProductProperties> Properties,
    IEnumerable<ProductCategory> Categories);

public record UpsertProduct(
    Guid? Id,
    string Name,
    string Title,
    string? ShortDescription,
    string? Description,
    decimal Amount,
    IEnumerable<ShopImage> Images,
    IEnumerable<UpsertProductProperties> Properties,
    IEnumerable<Guid> Categories,
    IEnumerable<Guid> Shops);

public record Tag(Guid Id, Guid AppId, string Name, string Title, string Code);

public record AddAllWithTagRequest(Guid TagId, Guid ShopId);