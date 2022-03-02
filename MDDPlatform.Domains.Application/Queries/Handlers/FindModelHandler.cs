using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers
{
    public class FindModelHandler : IQueryHandler<FindModel, ModelDto>
    {
        private readonly IDomainReader _domainReader;

        public FindModelHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }

        public ModelDto Handle(FindModel query)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelDto> HandleAsync(FindModel query)
        {
            return await _domainReader.FindModelAsync(query.DomainId,query.Name,query.Tag,query.Abstraction,query.Level);
        }
    }
}