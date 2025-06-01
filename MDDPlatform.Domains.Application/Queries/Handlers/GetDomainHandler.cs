using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers
{
    public class GetDomainHandler : IQueryHandler<GetDomain, DomainDto?>
    {
        private IDomainRepository _domainRepository;

        public GetDomainHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public DomainDto Handle(GetDomain query)
        {
            throw new NotImplementedException();
        }

        public async Task<DomainDto?> HandleAsync(GetDomain query)
        {
            var domain =  await _domainRepository.GetAsync(query.DomainId);
            if(Equals(domain,null))
                return null;

            return DomainDto.CreateFrom(domain);
        }
    }
}