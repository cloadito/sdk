using Cloudito.Sdk.Base.Fluent.Model;
using Cloudito.Sdk.Base.Fluent.Rest;

namespace Cloudito.Sdk.Base.Fluent.Builder;

 public interface IFluentRequestBuilder
    {
        IFluentRequestBuilder WithMethod(HttpMethod method);
        IFluentRequestBuilder WithBody(object body);
        IFluentRequestBuilder WithHeader(string name, string value);
        IFluentRequestBuilder WithRequestBuilder(Func<object?, string> builder);
        IFluentRequestBuilder WithResponseBuilder<T>(Func<string, T> builder);
        Task<ServiceResult<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default);
    }

    public class FluentRequestBuilder(IRest rest, string url) : IFluentRequestBuilder
    {
        private HttpMethod _method = HttpMethod.Get;
        private object? _body;
        private readonly Dictionary<string, string> _headers = new();
        private Func<object?, string>? _requestBuilder;
        private Func<string, object?>? _responseBuilder;

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
    }