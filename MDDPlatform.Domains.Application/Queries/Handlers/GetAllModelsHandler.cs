using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers 
{
    public class GetAllModelsHandler : IQueryHandler<GetAllModels, IList<ModelDto>>
    {
        private readonly IDomainReader _domainReader;

        public GetAllModelsHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }
        public IList<ModelDto> Handle(GetAllModels query)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ModelDto>> HandleAsync(GetAllModels query)
        {
            return await _domainReader.GetAllModelsAsync(query.DomainId);
        }
    }
}