using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Queries;

namespace MDDPlatform.Domains.Application.Queries.Handlers
{
    public class FindModelByIdHandler : IQueryHandler<FindModelById, ModelDto?>
    {
        private IDomainRepository _domainRepository;

        public FindModelByIdHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public ModelDto Handle(FindModelById query)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelDto?> HandleAsync(FindModelById query)
        {
            var domain = await _domainRepository.GetAsync(query.DomainId);
            if(Equals(domain,null))
                return null;
            
            var model = domain.Models.Where(model=> model.TraceId.Value == query.ModelId).FirstOrDefault();
            if(Equals(model,null))
                return null;
            
            return ModelDto.CreateFrom(model);
        }
    }
}