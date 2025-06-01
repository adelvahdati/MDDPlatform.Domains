using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands.Handlers;
public class CreatePackageFromDomainHandler : ICommandHandler<CreatePackageFromDomain>
{
    private readonly IDomainRepository _domainRepository;
    private readonly IPackageRepository _packageRepository;

    public CreatePackageFromDomainHandler(IDomainRepository domainRepository, IPackageRepository packageRepository)
    {
        _domainRepository = domainRepository;
        _packageRepository = packageRepository;
    }

    public void Handle(CreatePackageFromDomain command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePackageFromDomain command)
    {
        Domain? domain = await _domainRepository.GetAsync(command.DomainId);
        if (Equals(domain, null))
            throw new Exception("Domain Not Found");

        var templates = Package.CreateFrom(domain,command.Title);
        await _packageRepository.CreateAsync(templates);
    }
}
