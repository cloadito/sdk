namespace Cloudito.Sdk.Base.Fluent.Model;

public class ServiceResult<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public string? Message { get; }

    private ServiceResult(bool isSuccess, T? data, string? message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static ServiceResult<T> Success(T data) => new(true, data, null);
    public static ServiceResult<T> Fail(string message, T? data = default) => new(false, data, message);
}

public class ServiceResult<TSuccess, TError>
{
    public bool IsSuccess { get; }

    public TSuccess? SuccessDta { get; }

    public TError? Error { get; }
    public string? Message { get; }

    private ServiceResult(bool isSuccess, TSuccess? success, TError? error, string? message)
    {
        IsSuccess = isSuccess;
        SuccessDta = success;
        Error = error;
        Message = message;
    }

    public static ServiceResult<TSuccess, TError> Success(TSuccess data) => new(true, data, default, "");

    public static ServiceResult<TSuccess, TError> Fail(string message, TError? error) =>
        new(false, default, error, message);
}