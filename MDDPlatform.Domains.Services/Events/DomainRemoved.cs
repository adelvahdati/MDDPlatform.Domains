using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.Domains.Services.Evnets;
public class DomainRemoved : IDomainEvent
{
    public Guid DomainId {get;set;}
    public List<Guid> ModelIds {get;set;}

    public DomainRemoved(Guid domainId, List<Guid> modelIds)
    {
        DomainId = domainId;
        ModelIds = modelIds;
    }
}