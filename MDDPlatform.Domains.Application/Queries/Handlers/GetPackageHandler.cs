using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class GetPackageHandler : IQueryHandler<GetPackage, PackageDto?>
{
    private readonly IPackageRepository _packageRepository;

    public GetPackageHandler(IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }

    public PackageDto? Handle(GetPackage query)
    {
        throw new NotImplementedException();
    }

    public async Task<PackageDto?> HandleAsync(GetPackage query)
    {
        Package? package = await _packageRepository.GetAsync(query.PackageId);
        if(Equals(package,null))
            return null;
        
        return PackageDto.CreateFrom(package);
    }
}
