using MDDPlatform.Domains.Application.DTO;

namespace MDDPlatform.Domains.Application.Services
{
    public interface IDomainService
    {
        Task CreateModel(Guid domainId, NewModelDto newModel);
        Task<DomainDto> GetDomain(Guid domainId);
        Task<IList<ModelDto>> GetModels(Guid domainId); 
        Task<IList<ModelDto>> GetModels(Guid domainId,string name);
        Task<ModelDto> GetModel(Guid domainId,string name,string tag);
    }
}