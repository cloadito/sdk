using Newtonsoft.Json;

namespace Cloudito.Sdk.Base;

public record ApiResult<TModel>(int Code, bool Status, string Message, TModel? Result);

public record ServiceResult<TModel>(bool Success, string Message, TModel? Result)
{
    public static ServiceResult<TModel> Error(string msg)
        => new(false, msg, default);

    public static ServiceResult<TModel> FromApi(ApiResult<TModel> result)
        => new(result.Status, result.Message, result.Result);

    public override string ToString()
         => JsonConvert.SerializeObject(this, Formatting.Indented);

}