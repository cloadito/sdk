using Cloudito.Sdk.Base.Fluent.Model;

namespace Cloudito.Sdk.Base.Fluent.Rest;

public interface IRest
{
    Task<ApiResult<T>> SendAsync<T>(string url, HttpMethod method, object? body = null,
        CancellationToken token = default);

    Task<ApiModel<TSuccess, TError>> SendAsync<TSuccess, TError>(
        string url,
        HttpMethod method,
        object? body = null,
        CancellationToken cancellationToken = default);
}