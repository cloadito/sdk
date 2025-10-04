using Cloudito.Sdk.Base.Fluent.Rest;

namespace Cloudito.Sdk.Base.Fluent.Builder;

public interface IBaseService
{
    IFluentRequestBuilder From(string url);
}

public class BaseService(IRest rest) : IBaseService
{
    public IFluentRequestBuilder From(string url) => new FluentRequestBuilder(rest, url);
}