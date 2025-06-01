using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries;

public class GetProblemDomainModels : IQuery<List<ModelDto>>
{
    public Guid ProblemDomainId {get;set;}

    public GetProblemDomainModels(Guid problemDomainId)
    {
        ProblemDomainId = problemDomainId;
    }
}