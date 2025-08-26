using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Cloudito.Sdk.Base;

internal class Rest(IHttpClientFactory httpClientFactory) : IRest
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Settings.HttpClientName);

    public async Task<ApiResult<TModel>> GetAsync<TModel>(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync(url, cancellationToken);
            return await ProcessResponse<TModel>(response, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "GET request failed");
        }
    }

    public async Task<ApiResult<TModel>> PostAsync<TModel>(string url, object body,
        CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(url, body, cancellationToken);
            return await ProcessResponse<TModel>(response, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "POST request failed");
        }
    }

    public async Task<ApiResult<TModel>> DeleteAsync<TModel>(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(url, cancellationToken);
            return await ProcessResponse<TModel>(response, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "DELETE request failed");
        }
    }

    static async Task<ApiResult<TModel>> ProcessResponse<TModel>(HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (content.Contains("{}"))
        {
            if (typeof(TModel) == typeof(bool))
                content = content.Replace("{}", "false");
            if (typeof(TModel) == typeof(int))
                content = content.Replace("{}", "0");
        }

        if (!response.IsSuccessStatusCode)
            return new ApiResult<TModel>((int)response.StatusCode, false,
                response.ReasonPhrase ?? "Error", default);

        ApiResult<TModel>? result = JsonConvert.DeserializeObject<ApiResult<TModel>>(content);
        return result ??
               new ApiResult<TModel>((int)response.StatusCode, false, response.ReasonPhrase ?? "Error", default);
    }

    static ApiResult<TModel> HandleException<TModel>(Exception ex, string errorMessage)
        => new(500, false, $"{errorMessage}: {ex.Message}", default);


    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}