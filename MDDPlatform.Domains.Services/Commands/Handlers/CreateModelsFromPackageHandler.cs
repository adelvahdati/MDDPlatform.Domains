using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.Commands.Handlers;
public class CreateModelsFromPackageHandler : ICommandHandler<CreateModelsFromPackage>
{
    private readonly IDomainRepository _domainRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public CreateModelsFromPackageHandler(IDomainRepository domainRepository, IPackageRepository packageRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _domainRepository = domainRepository;
        _packageRepository = packageRepository;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(CreateModelsFromPackage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateModelsFromPackage command)
    {
        Domain? domain = await _domainRepository.GetAsync(command.DomainId);
        if(Equals(domain,null))
            throw new Exception("Domain Not Found");
        
        var package = await _packageRepository.GetAsync(command.PackageId);
        if(Equals(package,null))
            throw new Exception("Package Not Found");
        
        var modelTemplates = package.ModelTemplates;
        Dictionary<string,string> keyValues = new Dictionary<string, string>();
        keyValues.Add("Domain.Name",domain.Name);
        foreach(var template in modelTemplates)
        {
            var name = template.NameExpression.ResolveExpression(keyValues);
            var tag = template.TagExpression.ResolveExpression(keyValues);
            var abstractionLevel = template.Type.ToAbstractionLevel();
            var level  = template.Level;
            var languageId = template.Language.Id;
            var languageName = template.Language.Name;
            Language language = new Language(languageId,languageName);

            var action = domain.CreateModel(name,tag,abstractionLevel,level,language);
            if(action.Status == ActionStatus.Success)
            {
                await _domainRepository.UpdateAsync(domain);
                await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
                domain.ClearEvents();            
            }
        }
    }
}