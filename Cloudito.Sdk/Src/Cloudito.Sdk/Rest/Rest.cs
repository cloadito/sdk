using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Cloudito.Sdk;
internal class Rest(IHttpClientFactory httpClientFactory) : IRest
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Constants.HttpClientName);

    public async Task<ApiModel<TModel>> GetAsync<TModel>(string url)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            return await ProcessResponse<TModel>(response);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "GET request failed");
        }
    }

    public async Task<ApiModel<TModel>> PostAsync<TModel>(string url, object body)
    {
        try
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(url, body);
            return await ProcessResponse<TModel>(response);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "POST request failed");
        }
    }

    public async Task<ApiModel<TModel>> DeleteAsync<TModel>(string url)
    {
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(url);
            return await ProcessResponse<TModel>(response);
        }
        catch (HttpRequestException ex)
        {
            return HandleException<TModel>(ex, "DELETE request failed");
        }
    }

    static async Task<ApiModel<TModel>> ProcessResponse<TModel>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            ApiModel<TModel>? result = JsonConvert.DeserializeObject<ApiModel<TModel>>(content);
            return result is null ?
                new ApiModel<TModel>((int)response.StatusCode, false, response.ReasonPhrase ?? "Error", default)
                : result;
        }

        return new ApiModel<TModel>((int)response.StatusCode, false, response.ReasonPhrase ?? "Error", default);
    }

    static ApiModel<TModel> HandleException<TModel>(Exception ex, string errorMessage)
            => new(500, false, $"{errorMessage}: {ex.Message}", default);


    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}