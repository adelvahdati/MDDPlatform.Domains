using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.Commands.Handlers;
public class DeleteModelHandler : ICommandHandler<DeleteModel>
{
        private readonly IDomainRepository _domainRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

    public DeleteModelHandler(IDomainRepository domainRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _domainRepository = domainRepository;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(DeleteModel command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteModel command)
    {
        Domain? domain = await _domainRepository.GetAsync(command.DomainId);
        if(Equals(domain,null))
            return;
        
        domain.DeleteModel(command.ModelId);
        await _domainRepository.UpdateAsync(domain);
        await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
        domain.ClearEvents();
    }
}
