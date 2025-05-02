using Microsoft.AspNetCore.Http;

namespace Cloudito.Sdk.Finders;

internal class AppFinder : IAppFinder
{
    public async Task<Application?> FindAsync(HttpContext context)
    {
        var token = context.Request.Headers["X-Api-Key"];
        if (string.IsNullOrEmpty(token)) return null;
        return await FindAsync(token!);
    }

    public Task<Application?> FindAsync(string token)
    {
        token = IBaseFinder<Application>.RemovePerfix(token);
        return Task.FromResult(JwtTokenGenerator.GetAppDate(token));
    }

    public async Task<TResult> FindAsync<TResult>(HttpContext context, Func<TResult> notFound, Func<Application, Task<TResult>> action)
    {
        var app = await FindAsync(context);
        return app is null ?
            notFound()
            : await action(app);
    }

    public async Task<TResult> FindAsync<TResult>(HttpContext context, Func<Task<TResult>> notFound, Func<Application, Task<TResult>> action)
    {
        var app = await FindAsync(context);
        return app is null ?
           await notFound()
            : await action(app);
    }
}
