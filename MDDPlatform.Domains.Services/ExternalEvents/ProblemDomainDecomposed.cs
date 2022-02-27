using MDDPlatform.Messages.Events;

namespace MDDPlatform.Domains.Services.ExternalEvents
{
    public class ProblemDomainDecomposed : IEvent
    {
        public Guid ProblemDomainId { get;  set; }
        //public Guid SubDomainId { get; internal set; }
        public string SubDomain { get;  set; }
        public ProblemDomainDecomposed(Guid problemDomainId, string name)
        {
            ProblemDomainId = problemDomainId;
            //SubDomainId = domainId;
            SubDomain = name;
        }
    }
}