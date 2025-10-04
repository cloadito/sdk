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
    public static ServiceResult<T> Fail(string message) => new(false, default, message);
}