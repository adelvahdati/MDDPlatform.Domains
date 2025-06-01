using MDDPlatform.Domains.Services.Evnets;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.Domains.Services.ExternalEvents.Handlers;
public class SubDomainRemovedHandler : IEventHandler<SubDomainRemoved>
{
    private readonly IDomainRepository _domainRepositoty;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public SubDomainRemovedHandler(IDomainRepository domainRepositoty, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _domainRepositoty = domainRepositoty;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(SubDomainRemoved @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(SubDomainRemoved @event)
    {
        var domain = await _domainRepositoty.GetAsync(@event.DomainId);
        if(Equals(domain,null))
            throw new Exception("Domain Not Found");
        
        if(domain.ProblemDomain.Id!= @event.ProblemDomainId)
            throw new Exception("Problem Domain Id for this Sub-Domain is Invalid");
        
        await _domainRepositoty.DeleteAsync(domain);

        var modelIds = domain.Models.Select(m=>m.TraceId.Value).ToList();
        var _evnet = new DomainRemoved(domain.Id,modelIds);

        await _messageBroker.PublishAsync(_eventMapper.Map(_evnet));        
    }
}
