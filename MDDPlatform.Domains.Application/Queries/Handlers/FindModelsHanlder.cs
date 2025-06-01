using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Interfaces;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class FindModelsHandler : IQueryHandler<FindModels, List<ModelDto>>
{
    private readonly IDomainModelDataReader _dataReader ;

    public FindModelsHandler(IDomainModelDataReader dataReader)
    {
        _dataReader = dataReader;
    }

    public List<ModelDto> Handle(FindModels query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ModelDto>> HandleAsync(FindModels query)
    {
        return await _dataReader.FindModelsAsync(query);
    }
}
