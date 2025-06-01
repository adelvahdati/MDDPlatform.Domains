using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries 
{
    public class GetDomainModels : IQuery<List<ModelDto>>
    {
        public Guid DomainId {get; set;}

        public GetDomainModels(Guid domainId)
        {
            DomainId = domainId;
        }
    }
}