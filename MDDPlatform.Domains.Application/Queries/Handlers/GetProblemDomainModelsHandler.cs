using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class GetProblemDomainModelsHandler : IQueryHandler<GetProblemDomainModels, List<ModelDto>>
{
    private readonly IDomainRepository _domainRepository;

    public GetProblemDomainModelsHandler(IDomainRepository domainRepository)
    {
        this._domainRepository = domainRepository;
    }

    public List<ModelDto> Handle(GetProblemDomainModels query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ModelDto>> HandleAsync(GetProblemDomainModels query)
    {
        var models = await _domainRepository.GetProblemDomainModelsAsync(query.ProblemDomainId);
        return models.Select(model=>ModelDto.CreateFrom(model)).ToList();
    }
}
