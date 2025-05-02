using Microsoft.AspNetCore.Http;

namespace Cloudito.Sdk.Finders;

public interface IBaseFinder<TModel>
{
    Task<TModel?> FindAsync(HttpContext context);

    Task<TModel?> FindAsync(string token);

    Task<TResult> FindAsync<TResult>(HttpContext context, Func<TResult> notFound, Func<TModel, Task<TResult>> action);

    Task<TResult> FindAsync<TResult>(HttpContext context, Func<Task<TResult>> notFound, Func<TModel, Task<TResult>> action);

    public static string RemovePerfix(string token)
    {
        const string BearerPrefix = "Bearer ";
        return token.StartsWith(BearerPrefix, StringComparison.OrdinalIgnoreCase)
            ? token[BearerPrefix.Length..]
            : token;
    }
}
