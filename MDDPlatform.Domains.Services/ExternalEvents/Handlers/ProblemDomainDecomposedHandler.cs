using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.ExternalEvents.Handlers
{
    public class ProblemDomainDecomposedHandler : IEventHandler<ProblemDomainDecomposed>
    {
        private readonly IDomainWriter _domainWriter;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

        public ProblemDomainDecomposedHandler(IDomainWriter domainWriter,IMessageBroker messageBroker, IEventMapper eventMapper)
        {
            _domainWriter = domainWriter;
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

            Console.WriteLine($"Inside ProblemDomainDecomposedHandler - Domain name : {domainName}, problemId {problemDomainId}");

            //Check for duplication of event
            bool isDefined = await _domainWriter.IsDomainDefinedAsync(problemDomainId,domainName);
            if(isDefined)
            {
                Console.WriteLine("---> ProblemDomainDecomposedHandler : This domain is defined previously");
                return;
            }
            
            ProblemDomain problemDomain = new ProblemDomain(problemDomainId);            
            Domain domain = Domain.Create(problemDomain,domainId,domainName);
            await _domainWriter.CreateAsync(domain);
            
            await _messageBroker.PublishAsync(_eventMapper.Map(domain.DomainEvents.ToList()));
            domain.ClearEvents();
        }
    }
}