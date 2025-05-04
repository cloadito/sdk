namespace Cloudito.Sdk;

public record PaginationResult<TResult>(int PageCount, int ItemsCount, IEnumerable<TResult> Items);

public static class PaginationExtension
{
    public static PaginationResult<ToResult> FromPagination<FromResult, ToResult>(this PaginationResult<FromResult> res, IEnumerable<ToResult> items)
        => new PaginationResult<ToResult>(res.PageCount, res.ItemsCount, items);

    public static PaginationResult<TResult> ToPagination<TResult>(this IEnumerable<TResult> items, int itemsCount, int pageSize)
        => new(itemsCount.PageCount(pageSize), itemsCount, items);

    public static int PageCount(this int itemsCount, int pageSize)
            => itemsCount == 0
        ? 0
        : itemsCount / pageSize;
}