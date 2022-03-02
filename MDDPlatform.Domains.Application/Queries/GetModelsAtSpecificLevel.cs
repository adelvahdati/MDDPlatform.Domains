using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries 
{
    public class GetModelsAtSpecificLevel : IQuery<IList<ModelDto>>
    {
        public Guid DomainId {get; set;}
        public ModelAbstractions Abstraction {get;set;}
        public int Level {get;set;}

        public GetModelsAtSpecificLevel(Guid domainId, ModelAbstractions abstraction, int level)
        {
            DomainId = domainId;
            Abstraction = abstraction;
            Level = level;
        }
    }
}