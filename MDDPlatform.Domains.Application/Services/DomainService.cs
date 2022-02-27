using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Services.Commands;
using MDDPlatform.Messages.Dispatchers;

namespace MDDPlatform.Domains.Application.Services
{
    public class DomainService : IDomainService
    {
        private readonly IMessageDispatcher _messageDispatcher;

        public DomainService(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }
        public async Task CreateModel(Guid domainId, NewModelDto newModel)
        {
            var command = new CreateModel(domainId,newModel.Name,newModel.Tag);
            await _messageDispatcher.HandleAsync(command);
        }

        public async Task<DomainDto> GetDomain(Guid domainId)
        {
            var query = new GetDomain(domainId);
            return await _messageDispatcher.HandleAsync<DomainDto>(query);
        }

        public async Task<ModelDto> GetModel(Guid domainId,string name,string tag)
        {
            var query = new GetModel(domainId,name,tag);
            return await _messageDispatcher.HandleAsync<ModelDto>(query);
        }

        public async Task<IList<ModelDto>> GetModels(Guid domainId)
        {
            var query = new GetAllModels(domainId);
            return await _messageDispatcher.HandleAsync<IList<ModelDto>>(query);
        }

        public async Task<IList<ModelDto>> GetModels(Guid domainId, string name)
        {
            var query = new GetModelsByName(domainId,name);
            return await _messageDispatcher.HandleAsync<IList<ModelDto>>(query);
        }
    }
}