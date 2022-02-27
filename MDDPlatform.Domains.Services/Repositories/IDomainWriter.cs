using MDDPlatform.Domains.Core.Entities;

namespace MDDPlatform.Domains.Services.Repositories
{
    public interface IDomainWriter
    {
        Task CreateAsync(Domain domain);
        Task UpdateAsync(Domain domain);
        Task<bool> IsDomainDefinedAsync(Guid problemDomainId,string name);
        Task<Domain> GetAsync(Guid domainId);
    }

}