namespace Cloudito.Sdk;

public record Pagination<TResult>(int PageCount, int ItemsCount, IEnumerable<TResult> Items);

public static class PaginationExtension
{
    public static Pagination<ToResult> FromPagination<FromResult, ToResult>(this Pagination<FromResult> res, IEnumerable<ToResult> items)
        => new Pagination<ToResult>(res.PageCount, res.ItemsCount, items);

    public static Pagination<TResult> ToPagination<TResult>(this IEnumerable<TResult> items, int itemsCount, int pageSize)
        => new(itemsCount.PageCount(pageSize), itemsCount, items);

    public static int PageCount(this int itemsCount, int pageSize)
            => itemsCount == 0
        ? 0
        : itemsCount / pageSize;
}