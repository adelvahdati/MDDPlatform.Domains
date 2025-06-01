using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.Commands.Handlers
{
    public class CreateModelHandler : ICommandHandler<CreateModel>
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

        public CreateModelHandler(IDomainRepository domainRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
        {
            _domainRepository = domainRepository;
            _messageBroker = messageBroker;
            _eventMapper = eventMapper;
        }


        public void Handle(CreateModel command)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(CreateModel command)
        {

            Domain? domain = await _domainRepository.GetAsync(command.DomainId);                        
            if(Equals(domain,null))
                return;
            
            Language language = new Language(command.LanguageId,command.LanguageName);
            var action = domain.CreateModel(command.Name,command.Tag,command.Abstraction,command.Level,language);
            if(action.Status == ActionStatus.Failure)
                return;

            await _domainRepository.UpdateAsync(domain);
            await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
            domain.ClearEvents();            
        }
    }
}