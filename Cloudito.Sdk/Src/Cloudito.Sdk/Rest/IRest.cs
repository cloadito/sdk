namespace Cloudito.Sdk;

internal interface IRest : IDisposable
{
    Task<ApiResult<TModel>> GetAsync<TModel>(string url,CancellationToken cancellationToken = default);

    Task<ApiResult<TModel>> PostAsync<TModel>(string url, object body,CancellationToken cancellationToken = default);

    Task<ApiResult<TModel>> DeleteAsync<TModel>(string url,CancellationToken cancellationToken = default);
}
