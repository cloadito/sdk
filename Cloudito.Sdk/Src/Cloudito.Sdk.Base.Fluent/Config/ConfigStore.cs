namespace Cloudito.Sdk.Base.Fluent.Config;

public class FluentRestConfig
{
    /// <summary>
    /// Global request builder: transforms body object to string
    /// </summary>
    public Func<string, object?, string>? RequestBuilder { get; set; }

    /// <summary>
    /// Global response builder: transforms response string to object
    /// </summary>
    public Func<HttpResponseMessage, string, object?>? ResponseBuilder { get; set; }
}