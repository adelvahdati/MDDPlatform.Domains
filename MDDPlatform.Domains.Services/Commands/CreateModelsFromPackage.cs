using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands;
public class CreateModelsFromPackage : ICommand
{
    public Guid DomainId {get;set;}
    public Guid PackageId {get;set;}

    public CreateModelsFromPackage(Guid domainId, Guid packageId)
    {
        DomainId = domainId;
        PackageId = packageId;
    }
}