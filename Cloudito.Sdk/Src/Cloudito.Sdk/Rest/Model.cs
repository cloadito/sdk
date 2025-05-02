namespace Cloudito.Sdk;
public record ApiModel<TModel>(int Code, bool Status, string Message, TModel? Result);

public record ServiceResult<TModel>(bool Success, string Message, TModel? Result)
{
    public static ServiceResult<TModel> Error(string msg)
        => new(false, msg, default);

    public static ServiceResult<TModel> FromApi(ApiModel<TModel> result)
        => new(result.Status, result.Message, result.Result);
}