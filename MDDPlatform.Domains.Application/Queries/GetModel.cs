using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries{
    public class GetModel : IQuery<ModelDto>
    {
        public Guid DomainId {get;set;}
        public string Name {get;set;}
        public string Tag {get;set;}

        public GetModel(Guid domainId, string name, string tag)
        {
            DomainId = domainId;
            Name = name;
            Tag = tag;
        }
    }
}