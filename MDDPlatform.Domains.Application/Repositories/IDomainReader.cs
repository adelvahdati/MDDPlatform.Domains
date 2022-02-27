using MDDPlatform.Domains.Application.DTO;

namespace MDDPlatform.Domains.Application.Repository
{
    public interface IDomainReader
    {
        Task<DomainDto> GetDomain(Guid domainId);
        Task<IList<ModelDto>> GetAllModelsAsync(Guid domainId);
        Task<IList<ModelDto>> GetModelsByNameAsync(Guid domainId, string name);
        Task<ModelDto> GetModelAsync(Guid domainId, string name,string tag);
    }
}