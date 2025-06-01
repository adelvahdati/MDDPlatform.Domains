using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;
public class FindDomainModelById : IQuery<DomainModelDto?>{
    public Guid ModelId {get;set;}

    public FindDomainModelById(Guid modelId)
    {
        ModelId = modelId;
    }
}