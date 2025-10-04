using System.Text;
using Cloudito.Sdk.Base.Fluent.Config;
using Cloudito.Sdk.Base.Fluent.Model;
using Newtonsoft.Json;

namespace Cloudito.Sdk.Base.Fluent.Rest;

public class RestClient(IHttpClientFactory factory, string clientName, FluentRestConfig? config = null)
    : IRest
{
    private readonly IHttpClientFactory _factory = factory;
    private readonly FluentRestConfig _config = config ?? new FluentRestConfig();

    private HttpClient Client => _factory.CreateClient(clientName);

    public async Task<ApiResult<T>> SendAsync<T>(string url, HttpMethod method, object? body = null,
        CancellationToken token = default)
    {
        var request = new HttpRequestMessage(method, url);

        if (body is not null)
        {
            var content = _config.RequestBuilder?.Invoke(url, body) ?? JsonConvert.SerializeObject(body);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
        }

        var response = await Client.SendAsync(request, token);
        var responseContent = await response.Content.ReadAsStringAsync(token);

        if (!response.IsSuccessStatusCode)
            return new ApiResult<T>(default, false, responseContent);

        var data = _config.ResponseBuilder?.Invoke(response, responseContent)
                   ?? JsonConvert.DeserializeObject<T>(responseContent);

        return new ApiResult<T>((T?)data, true);
    }
}