using MDDPlatform.Domains.Application.DTO;

namespace MDDPlatform.Domains.Application.Services
{
    public interface IDomainService
    {
        Task CreateModelAsync(Guid domainId, NewModelDto newModel);
        Task DeleteModelAsync(Guid domainId,Guid modelId);
        Task<DomainDto?> GetDomainAsync(Guid domainId);
        Task<List<ModelDto>> GetDomainModelsAsync(Guid domainId);
        Task<List<ModelDto>> GetProblemDomainModelsAsync(Guid problemdDomainId);
        Task<ModelDto?> FindModelByIdAsync(Guid domainId, Guid modelId);
        Task<DomainModelDto?> FindDomainModelByIdAsync(Guid modelId);
        Task<List<DomainModelDto>?> FindDomainModelsByIdAsync(List<Guid> modelIds);

        Task<List<ModelDto>> GetCIMAsync(Guid domainId,string? name =null,string? tag =null,int level = default);
        Task<List<ModelDto>> GetPIMAsync(Guid domainId,string? name =null,string? tag =null,int level = default);
        Task<List<ModelDto>> GetPSMAsync(Guid domainId,string? name =null,string? tag =null,int level = default);
        Task<List<ModelDto>> GetCodeModelAsync(Guid domainId,string? name =null,string? tag =null,int level = default);
    }
}