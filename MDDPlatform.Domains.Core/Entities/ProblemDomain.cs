using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Core.Entities{
    public class ProblemDomain : BaseEntity<Guid>
    {
        public ProblemDomain(Guid id)
        {
            Id = id;
        }
    }
}