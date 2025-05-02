using Microsoft.AspNetCore.Http;

namespace Cloudito.Sdk.Finders;

internal class UserFinder : IUserFinder
{
    public async Task<User?> FindAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(token)) return null;
        return await FindAsync(token!);
    }

    public Task<User?> FindAsync(string token)
    {
        token = IBaseFinder<User>.RemovePerfix(token);
        return Task.FromResult(JwtTokenGenerator.GetUserData(token));
    }

    public async Task<TResult> FindAsync<TResult>(HttpContext context, Func<TResult> notFound, Func<User, Task<TResult>> action)
    {
        var user = await FindAsync(context);
        return user is null ?
            notFound() :
            await action(user);
    }

    public async Task<TResult> FindAsync<TResult>(HttpContext context, Func<Task<TResult>> notFound, Func<User, Task<TResult>> action)
    {
        var user = await FindAsync(context);
        return user is null ?
            await notFound()
            : await action(user);
    }
}
