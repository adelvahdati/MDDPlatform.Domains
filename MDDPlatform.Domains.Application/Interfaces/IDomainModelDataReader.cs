using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;

namespace MDDPlatform.Domains.Application.Interfaces;
public interface IDomainModelDataReader
{
    Task<DomainModelDto?> FindDomainModelAsync(Guid modelId);
    Task<List<DomainModelDto>?> FindDomainModelsAsync(List<Guid> modelIds);
    Task<List<ModelDto>> FindModelsAsync(FindModels query);
}