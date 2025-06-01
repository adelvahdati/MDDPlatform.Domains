using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Interfaces;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers;
public class FindDomainModelByIdHandler : IQueryHandler<FindDomainModelById, DomainModelDto?>
{
    private IDomainModelDataReader _domainModelDataReader;

    public FindDomainModelByIdHandler(IDomainModelDataReader domainModelDataReader)
    {
        _domainModelDataReader = domainModelDataReader;
    }

    public DomainModelDto? Handle(FindDomainModelById query)
    {
        throw new NotImplementedException();
    }

    public async Task<DomainModelDto?> HandleAsync(FindDomainModelById query)
    {
        return await _domainModelDataReader.FindDomainModelAsync(query.ModelId);
    }
}
