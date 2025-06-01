using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands.Handlers;
public class CreatePackageHandler : ICommandHandler<CreatePackage>
{
    private readonly IDomainRepository _domainRepository;
    private readonly IPackageRepository _packageRepository;

    public CreatePackageHandler(IDomainRepository domainRepository, IPackageRepository packageRepository)
    {
        _domainRepository = domainRepository;
        _packageRepository = packageRepository;
    }

    public void Handle(CreatePackage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePackage command)
    {
        var abstractModels = command.ModelTemplates.
                                        Select(model=>new ModelTemplate(
                                                            model.NameExpression,
                                                            model.TagExpression,
                                                            ModelType.Create(model.Type),
                                                            model.Level,
                                                            new Language(model.LanguageId,model.LanguageName)))
                                        .ToList();
        var package = new Package(command.Title,abstractModels);
        await _packageRepository.CreateAsync(package);
    }
}
