using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers{
    public class GetDomainHandler : IQueryHandler<GetDomain, DomainDto>
    {
        private readonly IDomainReader _domainReader;

        public GetDomainHandler(IDomainReader domainReader)
        {
            _domainReader = domainReader;
        }

        public DomainDto Handle(GetDomain query)
        {
            throw new NotImplementedException();
        }

        public async Task<DomainDto> HandleAsync(GetDomain query)
        {
            return await _domainReader.GetDomain(query.DomainId);
        }
    }
}