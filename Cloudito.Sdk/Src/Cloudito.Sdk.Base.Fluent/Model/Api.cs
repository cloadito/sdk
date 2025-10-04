using System.Net;

namespace Cloudito.Sdk.Base.Fluent.Model;

public class ApiResult<T>(T? data, bool success, string? error = null, HttpStatusCode statusCode = HttpStatusCode.OK)
{
    public bool Success { get; } = success;
    public T? Data { get; } = data;
    public string? Error { get; } = error;
    
    public HttpStatusCode StatusCode { get; } = statusCode;
}