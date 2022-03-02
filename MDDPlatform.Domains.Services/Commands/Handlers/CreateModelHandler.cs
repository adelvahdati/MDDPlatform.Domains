using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.Commands.Handlers
{
    public class CreateModelHandler : ICommandHandler<CreateModel>
    {
        private readonly IDomainWriter _domainWriter;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

        public CreateModelHandler(IDomainWriter domainWriter,IMessageBroker messageBroker, IEventMapper eventMapper)
        {
            _domainWriter = domainWriter;
            _messageBroker = messageBroker;
            _eventMapper = eventMapper;
        }
        public void Handle(CreateModel command)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(CreateModel command)
        {
            Domain domain = await _domainWriter.GetAsync(command.DomainId);
            var action = domain.CreateModel(command.Name,command.Tag,command.Abstraction,command.Level);
            if(action.Status == ActionStatus.Failure)
            {
                Console.WriteLine("---> CreateModelHandler : " + action.Message);
                return;
            }
                        
            await _domainWriter.UpdateAsync(domain);

            await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
            domain.ClearEvents();            
        }
    }
}