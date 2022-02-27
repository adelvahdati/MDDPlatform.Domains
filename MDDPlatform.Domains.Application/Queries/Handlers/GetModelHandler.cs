using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers
{
    public class GetModelHandler : IQueryHandler<GetModel, ModelDto>
    {
        private readonly IDomainReader _domainReader;

        public GetModelHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }

        public ModelDto Handle(GetModel query)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelDto> HandleAsync(GetModel query)
        {
            return await _domainReader.GetModelAsync(query.DomainId,query.Name,query.Tag);
        }
    }
}