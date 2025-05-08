namespace Cloudito.Sdk;

internal interface IRest : IDisposable
{
    Task<ApiResult<TModel>> GetAsync<TModel>(string url);

    Task<ApiResult<TModel>> PostAsync<TModel>(string url, object body);

    Task<ApiResult<TModel>> DeleteAsync<TModel>(string url);
}
