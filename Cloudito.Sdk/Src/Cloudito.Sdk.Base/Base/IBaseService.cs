using Cloudito.Sdk.Base;

namespace Cloudito.Sdk.Services;

public interface IBaseService
{
    Task<ServiceResult<T>> CallServiceAsync<T>(string url, object? body, HttpMethod method,
        CancellationToken cancellationToken = default);
    
    Task<ServiceResult<object>> CallServiceAsync(string url, object? body, HttpMethod method,
        CancellationToken cancellationToken = default);
}