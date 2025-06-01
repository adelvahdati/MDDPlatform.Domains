using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Infrastructure.MongoDB.Models;
using MDDPlatform.Domains.Services.Repositories;

namespace MDDPlatform.Domains.Infrastructure.MongoDB;
public class PackageRepository : IPackageRepository
{
    private IMongoRepository<PackageDocument, Guid> _repository;

    public PackageRepository(IMongoRepository<PackageDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Package package)
    {
        await _repository.AddAsync(PackageDocument.CreateFrom(package));
    }

    public async Task CreateOrUpdatePackageAsync(Package package)
    {
        await _repository.InsertOrReplaceAsync(PackageDocument.CreateFrom(package));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Package?> GetAsync(Guid id)
    {
        var packageDoc = await _repository.GetAsync(id);
        if(Equals(packageDoc,null))
            return null;
        
        return packageDoc.ToPackage();
    }

    public async Task<List<Package>> ListAsync()
    {
        var items = await _repository.ListAsync();
        if(Equals(items,null))
            return new();
        
        return items.Select(item=>item.ToPackage()).ToList();
    }

    public async Task UpdateAsync(Package package)
    {
        await _repository.UpdateAsync(PackageDocument.CreateFrom(package));
    }
}
