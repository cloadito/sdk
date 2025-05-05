namespace Cloudito.Sdk.Services;

internal interface IBaseService
{
    Task<ServiceResult<T>> CallServiceAsync<T>(string url, object? body, HttpMethod method);
}
