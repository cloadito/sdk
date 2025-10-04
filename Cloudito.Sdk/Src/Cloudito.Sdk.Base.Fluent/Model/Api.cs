namespace Cloudito.Sdk.Base.Fluent.Model;

public class ApiResult<T>(T? data, bool success, string? error = null)
{
    public bool Success { get; } = success;
    public T? Data { get; } = data;
    public string? Error { get; } = error;
}