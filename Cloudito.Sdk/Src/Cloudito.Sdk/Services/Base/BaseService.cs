using Microsoft.Extensions.Logging;

namespace Cloudito.Sdk.Services;

internal class BaseService(IRest rest, ILogger<BaseService> logger) : IBaseService
{
    public async Task<ServiceResult<T>> CallServiceAsync<T>(string url, object? body, HttpMethod method,
        CancellationToken cancellationToken = default)
    {
        var action = url.Split('/').Last();
        try
        {
            logger.LogInformation("Start call service {@Details}", new
            {
                Action = action,
                Method = method
            });

            var result = method.Method.ToLower() switch
            {
                "post" => await rest.PostAsync<T>(url, body ?? new { }, cancellationToken),
                "get" => await rest.GetAsync<T>(url, cancellationToken),
                "delete" => await rest.DeleteAsync<T>(url, cancellationToken),
                _ => await rest.GetAsync<T>(url, cancellationToken),
            };

            logger.LogInformation("Finished call service {@Details}", new
            {
                Action = action,
                Method = method,
                result.Status,
                result.Code,
            });

            return ServiceResult<T>.FromApi(result);
        }
        catch (Exception ex)
        {
            logger.LogError("Finished call service {@Details} {@Exception}", new
            {
                Action = action,
                Method = method
            }, ex);
            return ServiceResult<T>.Error(ex.Message);
        }
    }

    public Task<ServiceResult<object>> CallServiceAsync(string url, object? body, HttpMethod method,
        CancellationToken cancellationToken = default)
        => CallServiceAsync<object>(url, body, method, cancellationToken);
}