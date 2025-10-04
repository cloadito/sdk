using System.Text;
using System.Text.Json;
using Cloudito.Sdk.Base.Fluent.Config;
using Cloudito.Sdk.Base.Fluent.Model;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Cloudito.Sdk.Base.Fluent.Rest;

public class RestClient(IHttpClientFactory factory, string clientName, FluentRestConfig? config = null)
    : IRest
{
    private readonly FluentRestConfig _config = config ?? new FluentRestConfig();

    private HttpClient Client => factory.CreateClient(clientName);

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

        if (response.IsSuccessStatusCode)
        {
            var data = _config.ResponseBuilder?.Invoke(response, responseContent)
                       ?? JsonConvert.DeserializeObject<T>(responseContent);

            return new ApiResult<T>((T?)data, true, null, response.StatusCode);
        }
        else
        {
            // Try to parse the error message from JSON if possible
            string? errorMessage = responseContent;

            try
            {
                using var doc = JsonDocument.Parse(responseContent);
                if (doc.RootElement.TryGetProperty("message", out var msg))
                    errorMessage = msg.GetString();
                else if (doc.RootElement.TryGetProperty("error", out var err))
                    errorMessage = err.GetString();
            }
            catch
            {
                // Not JSON or no "message"/"error" property, fallback to raw content
            }

            return new ApiResult<T>(default, false, errorMessage ?? $"HTTP {response.StatusCode}", response.StatusCode);
        }
    }
}