namespace Cloudito.Sdk.Services;

internal class BaseService(IRest rest) : IBaseService
{
    public async Task<ServiceResult<T>> CallServiceAsync<T>(string url, object? body, HttpMethod method)
    {
        try
        {
            var result = method.Method.ToLower() switch
            {
                "post" => await rest.PostAsync<T>(url, body ?? new { }),
                "get" => await rest.GetAsync<T>(url),
                "delete" => await rest.DeleteAsync<T>(url),
                _ => await rest.GetAsync<T>(url),
            };

            return ServiceResult<T>.FromApi(result);
        }
        catch (Exception ex)
        {
            return ServiceResult<T>.Error(ex.Message);
        }
    }
}
