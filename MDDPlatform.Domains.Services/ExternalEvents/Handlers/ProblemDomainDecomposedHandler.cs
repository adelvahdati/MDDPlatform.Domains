using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.ExternalEvents.Handlers
{
    public class ProblemDomainDecomposedHandler : IEventHandler<ProblemDomainDecomposed>
    {
        private readonly IDomainRepository _domainRepositoty;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

        public ProblemDomainDecomposedHandler(IDomainRepository domainRepositoty, IMessageBroker messageBroker, IEventMapper eventMapper)
        {
            _domainRepositoty = domainRepositoty;
            _messageBroker = messageBroker;
            _eventMapper = eventMapper;
        }

        public void Handle(ProblemDomainDecomposed @event)
        {
            throw new NotImplementedException();            
        }

        public async Task HandleAsync(ProblemDomainDecomposed @event)
        {
            var domainName = @event.SubDomain;
            var problemDomainId = @event.ProblemDomainId;
            var domainId = @event.SubDomainId;


            //Check for duplication of event
            bool isDefined = await _domainRepositoty.IsDomainDefinedAsync(problemDomainId,domainName);
            if(isDefined)
                return;
            
            ProblemDomain problemDomain = new ProblemDomain(problemDomainId);            
            Domain domain = Domain.Create(problemDomain,domainId,domainName);
            await _domainRepositoty.CreateAsync(domain);
            
            await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
            domain.ClearEvents();
        }
    }
}