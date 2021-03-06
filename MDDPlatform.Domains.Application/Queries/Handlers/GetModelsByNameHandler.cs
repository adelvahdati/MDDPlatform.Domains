using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers{
    public class GetModelsByNameHandler : IQueryHandler<GetModelsByName, IList<ModelDto>>
    {
        private readonly IDomainReader _domainReader;

        public GetModelsByNameHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }

        public IList<ModelDto> Handle(GetModelsByName query)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ModelDto>> HandleAsync(GetModelsByName query)
        {
            return await _domainReader.GetModelsByNameAsync(query.DomainId,query.Name,query.Abstraction,query.Level);
        }
    }
}