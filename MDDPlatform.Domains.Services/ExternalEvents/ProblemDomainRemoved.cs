using MDDPlatform.Messages.Events;

namespace MDDPlatform.Domains.Services.ExternalEvents;
public class ProblemDomainRemoved : IEvent
{
    public Guid ProblemDomainId {get;set;}
    public List<Guid> DomainIds {get;set;}

    public ProblemDomainRemoved(Guid problemDomainId, List<Guid> domainIds)
    {
        ProblemDomainId = problemDomainId;
        DomainIds = domainIds;
    }
}