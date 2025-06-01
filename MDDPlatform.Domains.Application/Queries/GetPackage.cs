using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;
public class GetPackage : IQuery<PackageDto?>
{
    public Guid PackageId {get;set;}

    public GetPackage(Guid packageId)
    {
        this.PackageId = packageId;
    }
}