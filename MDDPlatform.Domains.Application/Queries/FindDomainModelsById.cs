using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;
public class FindDomainModelsById : IQuery<List<DomainModelDto>?>
{
    public List<Guid> ModelIds {get;set;}

    public FindDomainModelsById(List<Guid> modelIds)
    {
        ModelIds = modelIds;
    }
}