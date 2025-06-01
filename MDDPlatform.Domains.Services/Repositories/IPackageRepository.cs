using MDDPlatform.Domains.Core.Entities;

namespace MDDPlatform.Domains.Services.Repositories;
public interface IPackageRepository
{
    Task CreateAsync(Package package);
    Task UpdateAsync(Package package);
    Task<Package?> GetAsync(Guid id);
    Task<List<Package>> ListAsync();
    Task DeleteAsync(Guid id);
    Task CreateOrUpdatePackageAsync(Package package);
}