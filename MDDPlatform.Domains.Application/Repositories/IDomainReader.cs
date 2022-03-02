using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;

namespace MDDPlatform.Domains.Application.Repository
{
    public interface IDomainReader
    {
        Task<DomainDto> GetDomain(Guid domainId);
        Task<IList<ModelDto>> GetAllModelsAsync(Guid domainId);
        Task<IList<ModelDto>> GetModelsByNameAsync(Guid domainId, string name,ModelAbstractions abstraction,int level);
        Task<ModelDto> FindModelAsync(Guid domainId, string name,string tag,ModelAbstractions abstraction,int level);
        Task<IList<ModelDto>> GetModelsAtSpecificLevelAsync(Guid domainId,ModelAbstractions abstraction,int level);
    }
}