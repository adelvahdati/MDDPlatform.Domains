using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries
{
    public class GetDomain : IQuery<DomainDto>
    {
        public Guid DomainId{get;}

        public GetDomain(Guid domainId)
        {
            DomainId = domainId;
        }
    }
}