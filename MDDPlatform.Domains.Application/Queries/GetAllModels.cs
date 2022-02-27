using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries 
{
    public class GetAllModels : IQuery<IList<ModelDto>>
    {
        public Guid DomainId {get; set;}

        public GetAllModels(Guid domainId)
        {
            DomainId = domainId;
        }
    }
}