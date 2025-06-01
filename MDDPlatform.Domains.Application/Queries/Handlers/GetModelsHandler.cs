using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class GetModelsHandler : IQueryHandler<GetModels, List<ModelDto>>
{
    private readonly IDomainRepository _domainRepository;

    public GetModelsHandler(IDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public List<ModelDto> Handle(GetModels query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ModelDto>> HandleAsync(GetModels query)
    {
        bool filterByName = query.FilterByName.IsApplied;
        bool filterByTag = query.FilterByTag.IsApplied;
        bool filterByType = query.FilterByType.IsApplied;
        bool filterByLevel = query.FilterByLevel.IsApplied;
        Func<Model,bool> predicate = model => (!filterByName || model.Name == query.FilterByName.Value) &&
                                                (!filterByTag || model.Tag == query.FilterByTag.Value) &&
                                                (!filterByType || model.Type.Value == query.FilterByType.Value) &&
                                                (!filterByLevel || model.Level == query.FilterByLevel.Value);

        var models =  await _domainRepository.GetModelsAsync(query.DomainId,predicate);
        return models.Select(model=> ModelDto.CreateFrom(model)).ToList();

    }
}
