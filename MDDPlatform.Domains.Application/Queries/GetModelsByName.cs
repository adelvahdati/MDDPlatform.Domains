using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries{
    public class GetModelsByName : IQuery<IList<ModelDto>>
    {
        public Guid DomainId {get;set;}
        public string Name {get;set;}
        public ModelAbstractions Abstraction {get;set;}
        public int Level {get;set;}

        public GetModelsByName(Guid domainId, string name, ModelAbstractions abstraction, int level)
        {
            DomainId = domainId;
            Name = name;
            Abstraction = abstraction;
            Level = level;
        }
    }
}