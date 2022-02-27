using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries{
    public class GetModelsByName : IQuery<IList<ModelDto>>
    {
        public Guid DomainId {get;set;}
        public string Name {get;set;}

        public GetModelsByName(Guid domainId, string name)
        {
            DomainId = domainId;
            Name = name;
        }
    }
}