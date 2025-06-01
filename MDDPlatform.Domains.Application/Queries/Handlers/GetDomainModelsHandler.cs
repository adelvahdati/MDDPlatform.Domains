using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers
{
    public class GetDomainModelsHandler : IQueryHandler<GetDomainModels, List<ModelDto>>
    {
        private readonly IDomainRepository _domainRepository;

        public GetDomainModelsHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }
        public List<ModelDto> Handle(GetDomainModels query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ModelDto>> HandleAsync(GetDomainModels query)
        {
            var models =  await _domainRepository.GetModelsAsync(query.DomainId);
            return models.Select(model=> ModelDto.CreateFrom(model)).ToList();
        }
    }
}