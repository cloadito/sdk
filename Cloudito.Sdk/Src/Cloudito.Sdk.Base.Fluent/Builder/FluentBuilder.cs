using System.Net;
using Cloudito.Sdk.Base.Fluent.Model;
using Cloudito.Sdk.Base.Fluent.Rest;
using Newtonsoft.Json;

namespace Cloudito.Sdk.Base.Fluent.Builder;

public interface IFluentRequestBuilder
{
    IFluentRequestBuilder WithMethod(HttpMethod method);
    IFluentRequestBuilder WithBody(object body);
    IFluentRequestBuilder WithHeader(string name, string value);
    IFluentRequestBuilder WithRequestBuilder(Func<object?, string> builder);
    IFluentRequestBuilder WithResponseBuilder<T>(Func<string, T> builder);
    IFluentRequestBuilder OnSuccess<T>(Func<string, T> successBuilder);
    IFluentRequestBuilder OnError(Func<HttpStatusCode, string, string> errorBuilder);
    IFluentRequestBuilder OnError<TError>(Func<string, TError> builder);

    Task<ServiceResult<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default);

    Task<ServiceResult<object>> ExecuteAsync(CancellationToken cancellationToken = default);

    Task<ServiceResult<TSuccess, TError>> ExecuteAsync<TSuccess, TError>(CancellationToken cancellationToken = default);
}

public class FluentRequestBuilder(IRest rest, string url) : IFluentRequestBuilder
{
    private HttpMethod _method = HttpMethod.Get;
    private object? _body;
    private readonly Dictionary<string, string> _headers = new();
    private Func<object?, string>? _requestBuilder;
    private Func<string, object?>? _responseBuilder;
    private Func<string, object?>? _successBuilder;
    private Func<HttpStatusCode, string, string>? _errorBuilder;
    private Func<string, object>? _terrorBuilder;

    public IFluentRequestBuilder WithMethod(HttpMethod method)
    {
        _method = method;
        return this;
    }

    public IFluentRequestBuilder WithBody(object body)
    {
        _body = body;
        return this;
    }

    public IFluentRequestBuilder WithHeader(string name, string value)
    {
        _headers[name] = value;
        return this;
    }

    public IFluentRequestBuilder WithRequestBuilder(Func<object?, string> builder)
    {
        _requestBuilder = builder;
        return this;
    }

    public IFluentRequestBuilder WithResponseBuilder<T>(Func<string, T> builder)
    {
        _responseBuilder = json => builder(json);
        return this;
    }

    public IFluentRequestBuilder OnError<TError>(Func<string, TError> builder)
    {
        _terrorBuilder = s => builder(s);
        return this;
    }


    public IFluentRequestBuilder OnSuccess<T>(Func<string, T> successBuilder)
    {
        _successBuilder = json => successBuilder(json);
        return this;
    }

    public IFluentRequestBuilder OnError(Func<HttpStatusCode, string, string> errorBuilder)
    {
        _errorBuilder = errorBuilder;
        return this;
    }

    public async Task<ServiceResult<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default)
    {
        // If per-request builder exists, temporarily override the global config
        if (rest is RestClient client)
        {
            // Note: currently, headers are not handled in RestClient, we can extend later
            var result = await client.SendAsync<T>(url, _method, _body, cancellationToken);
            return result.Success
                ? ServiceResult<T>.Success(result.Data!)
                : ServiceResult<T>.Fail(result.Error ?? "Request failed");
        }

        return ServiceResult<T>.Fail("Invalid rest client");
    }

    public async Task<ServiceResult<object>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        if (rest is not RestClient client)
            return ServiceResult<object>.Fail("Invalid RestClient");

        var result = await client.SendAsync<object>(url, _method, _body, cancellationToken);

        if (result.Success)
        {
            if (_successBuilder == null)
                return ServiceResult<object>.Success(result.Data ?? new object());
            // Use OnSuccess builder if provided
            var data = _successBuilder(result.Data?.ToString() ?? "");
            return ServiceResult<object>.Success(data!);

            // fallback: raw data from RestClient
        }

        if (_errorBuilder == null)
            return ServiceResult<object>.Fail(result.Error ?? "Request failed");
        var err = _errorBuilder(result.StatusCode, result.Error ?? "Unknown error");
        return ServiceResult<object>.Fail(err);
    }

    public async Task<ServiceResult<TSuccess, TError>> ExecuteAsync<TSuccess, TError>(
        CancellationToken cancellationToken = default)
    {
        var result = await rest.SendAsync<TSuccess, TError>(url, _method, _body, cancellationToken);

        if (result.IsSuccess)
        {
            var data = _successBuilder != null
                ? (TSuccess)_successBuilder(JsonConvert.SerializeObject(result.Success))
                : result.Success!;
            return ServiceResult<TSuccess, TError>.Success(data);
        }
        else
        {
            var error = _terrorBuilder != null
                ? (TError)_terrorBuilder(JsonConvert.SerializeObject(result.Error))
                : result.Error!;
            return ServiceResult<TSuccess, TError>.Fail(error);
        }
    }
}