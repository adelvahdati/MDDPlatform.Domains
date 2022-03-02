using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers{
    public class GetModelsAtSpecificLevelHandler : IQueryHandler<GetModelsAtSpecificLevel, IList<ModelDto>>
    {
        private readonly IDomainReader _domainReader;

        public GetModelsAtSpecificLevelHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }

        public IList<ModelDto> Handle(GetModelsAtSpecificLevel query)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ModelDto>> HandleAsync(GetModelsAtSpecificLevel query)
        {
            return await _domainReader.GetModelsAtSpecificLevelAsync(query.DomainId,query.Abstraction,query.Level);
        }
    }
}