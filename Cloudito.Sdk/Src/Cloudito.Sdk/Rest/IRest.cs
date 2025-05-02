namespace Cloudito.Sdk;

internal interface IRest : IDisposable
{
    Task<ApiModel<TModel>> GetAsync<TModel>(string url);

    Task<ApiModel<TModel>> PostAsync<TModel>(string url, object body);

    Task<ApiModel<TModel>> DeleteAsync<TModel>(string url);
}
