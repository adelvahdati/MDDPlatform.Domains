using MDDPlatform.DomainModels.Core.Enums;
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
        public async Task CreateModelAsync(Guid domainId, NewModelDto newModel)
        {

            ModelAbstractions modelAbstraction = default;
            bool result = Enum.TryParse(newModel.Type,true,out modelAbstraction);
            if(!result)
                modelAbstraction = ModelAbstractions.Undefined;
            var command = new CreateModel(domainId, newModel.Name, newModel.Tag, modelAbstraction,newModel.Level);
            await _messageDispatcher.HandleAsync(command);
        }

        public async Task<DomainDto> GetDomainAsync(Guid domainId)
        {
            var query = new GetDomain(domainId);
            return await _messageDispatcher.HandleAsync<DomainDto>(query);
        }

        public async Task<ModelDto> FindModelAsync(Guid domainId, string name, string tag,ModelAbstractions abstraction,int level)
        {
            var query = new FindModel(domainId, name, tag,abstraction, level);
            return await _messageDispatcher.HandleAsync<ModelDto>(query);
        }

        public async Task<IList<ModelDto>> GetAllModelsAsync(Guid domainId)
        {
            var query = new GetAllModels(domainId);
            return await _messageDispatcher.HandleAsync<IList<ModelDto>>(query);
        }

        public async Task<IList<ModelDto>> GetModelsByNameAsync(Guid domainId, string name,ModelAbstractions abstraction,int level)
        {
            var query = new GetModelsByName(domainId, name,abstraction, level);
            return await _messageDispatcher.HandleAsync<IList<ModelDto>>(query);
        }
        public async Task<IList<ModelDto>> GetModelsAtSpecificLevelAsync(Guid domainId,ModelAbstractions abstraction,int level)
        {
            var query = new GetModelsAtSpecificLevel(domainId,abstraction, level);
            return await _messageDispatcher.HandleAsync<IList<ModelDto>>(query);
        }
    }
}