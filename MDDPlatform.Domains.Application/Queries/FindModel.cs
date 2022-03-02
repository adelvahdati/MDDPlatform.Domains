using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries{
    public class FindModel : IQuery<ModelDto>
    {
        public Guid DomainId {get;set;}
        public string Name {get;set;}
        public string Tag {get;set;}
        public ModelAbstractions Abstraction {get;set;}
        public int Level {get;set;}

        public FindModel(Guid domainId, string name, string tag, ModelAbstractions abstraction,int level)
        {
            DomainId = domainId;
            Name = name;
            Tag = tag;
            Abstraction = abstraction;
            Level = level;
        }
    }
}