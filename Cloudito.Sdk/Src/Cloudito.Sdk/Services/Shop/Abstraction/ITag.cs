namespace Cloudito.Sdk.Services;

public interface ITag
{
    Task<ServiceResult<IEnumerable<Tag>>> GetListAsync(CancellationToken cancellationToken = default);

    Task<ServiceResult<Tag>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<ServiceResult<Tag>> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}