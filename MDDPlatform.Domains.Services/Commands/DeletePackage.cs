using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands;
public class DeletePackage : ICommand{
    public Guid PackageId {get;set;}

    public DeletePackage(Guid packageId)
    {
        PackageId = packageId;
    }
}