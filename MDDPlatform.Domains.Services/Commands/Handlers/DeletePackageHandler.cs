using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands.Handlers;
public class DeletePackageHandler : ICommandHandler<DeletePackage>
{
    private readonly IPackageRepository _packageRepository;

    public DeletePackageHandler(IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }

    public void Handle(DeletePackage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeletePackage command)
    {
        await _packageRepository.DeleteAsync(command.PackageId);
    }
}