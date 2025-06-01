using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;
public class GetModels : IQuery<List<ModelDto>>
{
    public Guid DomainId {get; set;}
    public Filter<string> FilterByName {get;}
    public Filter<string> FilterByTag {get;}
    public Filter<string> FilterByType {get;} 
    public Filter<int> FilterByLevel {get;}

    public GetModels(Guid domainId, Filter<string> filterByName, Filter<string> filterByTag, Filter<string> filterByType, Filter<int> filterByLevel)
    {
        DomainId = domainId;
        FilterByName = filterByName;
        FilterByTag = filterByTag;
        FilterByType = filterByType;
        FilterByLevel = filterByLevel;
    }
}