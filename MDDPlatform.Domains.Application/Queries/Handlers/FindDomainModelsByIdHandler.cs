using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Interfaces;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class FindDomainModelsByIdHandler : IQueryHandler<FindDomainModelsById, List<DomainModelDto>?>
{
    private IDomainModelDataReader _domainModelDataReader;

    public FindDomainModelsByIdHandler(IDomainModelDataReader domainModelDataReader)
    {
        _domainModelDataReader = domainModelDataReader;
    }

    public List<DomainModelDto>? Handle(FindDomainModelsById query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DomainModelDto>?> HandleAsync(FindDomainModelsById query)
    {
        return await _domainModelDataReader.FindDomainModelsAsync(query.ModelIds);
    }
}
