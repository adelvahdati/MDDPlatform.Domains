using MDDPlatform.Domains.Services.Evnets;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.ExternalEvents.Handlers;
public class ProblemDomainRemovedHandler : IEventHandler<ProblemDomainRemoved>
{
    private readonly IDomainRepository _domainRepositoty;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;
    public ProblemDomainRemovedHandler(IDomainRepository domainRepositoty, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _domainRepositoty = domainRepositoty;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(ProblemDomainRemoved @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ProblemDomainRemoved @event)
    {
        if(@event.DomainIds == null)
            return;
        
        foreach(var domainId in @event.DomainIds)
        {
            var domain = await _domainRepositoty.GetAsync(domainId);
            if(Equals(domain,null))
                continue;
            
            if(domain.ProblemDomain.Id!= @event.ProblemDomainId)
                continue;
            
            await _domainRepositoty.DeleteAsync(domain);

            var modelIds = domain.Models.Select(m=>m.TraceId.Value).ToList();
            var _evnet = new DomainRemoved(domain.Id,modelIds);

            await _messageBroker.PublishAsync(_eventMapper.Map(_evnet));
        }
    }
}
