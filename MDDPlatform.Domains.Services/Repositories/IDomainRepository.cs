using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Services.Repositories;
public interface IDomainRepository
{
    Task CreateAsync(Domain domain);
    Task UpdateAsync(Domain domain);
    Task<bool> IsDomainDefinedAsync(Guid problemDomainId, string name);
    Task<Domain?> GetAsync(Guid domainId);

    Task<List<Model>> GetModelsAsync(Guid domainId);
    Task<List<Model>> GetModelsAsync(Guid domainId, Func<Model, bool> predicate);
    Task<List<Model>> GetProblemDomainModelsAsync(Guid problemDomainId);
    Task DeleteAsync(Domain domain);    
}