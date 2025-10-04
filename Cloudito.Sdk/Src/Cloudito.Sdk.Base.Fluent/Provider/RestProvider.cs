using Cloudito.Sdk.Base.Fluent.Builder;
using Cloudito.Sdk.Base.Fluent.Rest;

namespace Cloudito.Sdk.Base.Fluent.Provider;

public interface IRestClientProvider
{
    IBaseService GetService(string name);
    IRest GetClient(string name);
}

public class RestClientProvider : IRestClientProvider
{
    private readonly Dictionary<string, NamedRestClient> _clients;

    public RestClientProvider(IEnumerable<NamedRestClient> clients)
    {
        _clients = clients.ToDictionary(c => c.Name, c => c, StringComparer.OrdinalIgnoreCase);
    }

    public IBaseService GetService(string name) => _clients[name].Service;
    public IRest GetClient(string name) => _clients[name].Client;
}

public class NamedRestClient(string name, IRest client)
{
    public string Name { get; } = name;
    public IRest Client { get; } = client;
    public IBaseService Service { get; } = new BaseService(client);
}
