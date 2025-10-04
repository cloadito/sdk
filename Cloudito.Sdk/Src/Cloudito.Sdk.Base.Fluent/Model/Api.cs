using System.Net;

namespace Cloudito.Sdk.Base.Fluent.Model;

public class ApiResult<T>(T? data, bool success, string? error = null, HttpStatusCode statusCode = HttpStatusCode.OK)
{
    public bool Success { get; } = success;
    public T? Data { get; } = data;
    public string? Error { get; } = error;
    
    public HttpStatusCode StatusCode { get; } = statusCode;
}

public class ApiModel<TSuccess, TError>
{
    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;
    public TSuccess? Success { get; }
    public TError? Error { get; }
    public HttpStatusCode StatusCode { get; }

    private ApiModel(bool success, TSuccess? successData, TError? errorData, HttpStatusCode statusCode)
    {
        IsSuccess = success;
        Success = successData;
        Error = errorData;
        StatusCode = statusCode;
    }

    public static ApiModel<TSuccess, TError> FromSuccess(TSuccess data, HttpStatusCode code = HttpStatusCode.OK)
        => new(true, data, default, code);

    public static ApiModel<TSuccess, TError> FromError(TError error, HttpStatusCode code = HttpStatusCode.BadRequest)
        => new(false, default, error, code);
}
