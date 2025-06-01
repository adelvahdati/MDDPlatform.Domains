using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class ListPackagesHandler : IQueryHandler<ListPackages, List<PackageDto>>
{
    private readonly IPackageRepository _packageRepository;

    public ListPackagesHandler(IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }

    public List<PackageDto> Handle(ListPackages query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PackageDto>> HandleAsync(ListPackages query)
    {
        var items = await _packageRepository.ListAsync();
        if(Equals(items,null))
            return new();
        
        return items.Select(item=> PackageDto.CreateFrom(item)).ToList();

    }
}
