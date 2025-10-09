namespace Cloudito.Sdk.Services;

internal class TagService(IBaseService baseService) : ITag
{
    public Task<ServiceResult<IEnumerable<Tag>>> GetListAsync(CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<IEnumerable<Tag>>(UrlsConst.Shop.Tag.GetList, null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<Tag>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Tag>(UrlsConst.Shop.Tag.GetByName(name), null, HttpMethod.Get,
            cancellationToken);

    public Task<ServiceResult<Tag>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        => baseService.CallServiceAsync<Tag>(UrlsConst.Shop.Tag.GetByCode(code), null, HttpMethod.Get,
            cancellationToken);
}