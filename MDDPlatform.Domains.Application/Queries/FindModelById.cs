using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries{
    public class FindModelById : IQuery<ModelDto?>
    {
        public Guid DomainId {get;set;}
        public Guid ModelId {get;set;}

        public FindModelById(Guid domainId, Guid modelId)
        {
            DomainId = domainId;
            ModelId = modelId;
        }
    }
}