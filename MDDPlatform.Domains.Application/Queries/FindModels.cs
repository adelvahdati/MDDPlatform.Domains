using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;
public class FindModels : IQuery<List<ModelDto>>
{
    public FilterDto<Guid> FilterByProblemDomain {get;set;}
    public FilterDto<Guid> FilterByDomain {get;set;}
    public FilterDto<string> FilterByName {get;set;}
    public FilterDto<string> FilterByAbstractionLevel {get;set;}
    public FilterDto<string> FilterByTag {get;set;}
    public FilterDto<Guid> FilterByLnaguage {get;set;}

    public FindModels(FilterDto<Guid> filterByProblemDomain, FilterDto<Guid> filterByDomain, FilterDto<string> filterByName, FilterDto<string> filterByAbstractionLevel, FilterDto<string> filterByTag, FilterDto<Guid> filterByLnaguage)
    {
        FilterByProblemDomain = filterByProblemDomain;
        FilterByDomain = filterByDomain;
        FilterByName = filterByName;
        FilterByAbstractionLevel = filterByAbstractionLevel;
        FilterByTag = filterByTag;
        FilterByLnaguage = filterByLnaguage;
    }
}