using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.Domains.Core.Events
{
    internal class DomainCreated : IDomainEvent
    {
        private Guid ProblemDomainId;
        private Guid DomainId;
        private string Name;

        public DomainCreated(Guid problemDomainId, Guid domainId, string name)
        {
            ProblemDomainId = problemDomainId;
            DomainId = domainId;
            Name = name;
        }
    }
}