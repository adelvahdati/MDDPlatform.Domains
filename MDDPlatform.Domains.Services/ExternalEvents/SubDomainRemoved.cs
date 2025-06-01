using MDDPlatform.Messages.Events;

namespace MDDPlatform.Domains.Services.ExternalEvents;
public class SubDomainRemoved : IEvent
{
    public Guid ProblemDomainId { get; }
    public string ProblemDomainTitle { get; }
    public Guid DomainId { get; }
    public string DomainName { get; }

    public SubDomainRemoved(Guid problemDomainId,string problemDomainTitle,Guid domainId,string domainName){
        ProblemDomainId = problemDomainId;
        ProblemDomainTitle = problemDomainTitle;
        DomainId = domainId;
        DomainName = domainName;
    }
}

