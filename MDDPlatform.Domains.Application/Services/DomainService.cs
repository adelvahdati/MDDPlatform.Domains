using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Core.ValueObjects;
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
            var command = new CreateModel(domainId, 
                                            newModel.Name, 
                                            newModel.Tag, 
                                            modelAbstraction,
                                            newModel.Level,
                                            newModel.Language.Id,
                                            newModel.Language.Name);
            await _messageDispatcher.HandleAsync(command);
        }
        public async Task DeleteModelAsync(Guid domainId, Guid modelId)
        {
            var command = new DeleteModel(domainId,modelId);
            await _messageDispatcher.HandleAsync(command);
        }

        public async Task<ModelDto?> FindModelByIdAsync(Guid domainId, Guid modelId)
        {
            var query = new FindModelById(domainId,modelId);
            return await _messageDispatcher.HandleAsync<ModelDto?>(query);
        }


        public async Task<DomainDto?> GetDomainAsync(Guid domainId)
        {
            var query = new GetDomain(domainId);
            return await _messageDispatcher.HandleAsync<DomainDto?>(query);
        }

        public async Task<List<ModelDto>> GetDomainModelsAsync(Guid domainId)
        {
            var query = new GetDomainModels(domainId);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }
        public async Task<List<ModelDto>> GetCIMAsync(Guid domainId, string? name = null, string? tag = null, int level = default)
        {
            string modelType = ModelType.CIM().Value;
            var query = BuildModelsQuery(domainId,modelType,name,tag,level);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }

        public async Task<List<ModelDto>> GetPIMAsync(Guid domainId, string? name = null, string? tag = null, int level = default)
        {
            string modelType = ModelType.PIM().Value;
            var query = BuildModelsQuery(domainId,modelType,name,tag,level);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }

        public async Task<List<ModelDto>> GetPSMAsync(Guid domainId, string? name = null, string? tag = null, int level = default)
        {
            string modelType = ModelType.PSM().Value;
            var query = BuildModelsQuery(domainId,modelType,name,tag,level);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }
        public async Task<List<ModelDto>> GetCodeModelAsync(Guid domainId, string? name = null, string? tag = null, int level = default)
        {
            string modelType = ModelType.Code().Value;
            var query = BuildModelsQuery(domainId,modelType,name,tag,level);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }
        private GetModels BuildModelsQuery(Guid domainId,string modelType ,string? name = null, string? tag = null, int level = default)
        {
            Filter<string> filterByName = name == null? Filter<string>.DontCare() : Filter<string>.Create(name);
            Filter<string> filterByTag = tag == null? Filter<string>.DontCare() : Filter<string>.Create(tag);
            Filter<string> filterByType = Filter<string>.Create(modelType);
            Filter<int> filterByLevel = level == default? Filter<int>.DontCare() : Filter<int>.Create(level);
            return new GetModels(domainId,filterByName,filterByTag,filterByType,filterByLevel);
        }

        public async Task<List<ModelDto>> GetProblemDomainModelsAsync(Guid problemdDomainId)
        {
            var query = new GetProblemDomainModels(problemdDomainId);
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }

        public async Task<DomainModelDto?> FindDomainModelByIdAsync(Guid modelId)
        {
            var query = new FindDomainModelById(modelId);
            return await _messageDispatcher.HandleAsync<DomainModelDto?>(query);
        }

        public async Task<List<DomainModelDto>?> FindDomainModelsByIdAsync(List<Guid> modelIds)
        {
            var query = new FindDomainModelsById(modelIds);
            return await _messageDispatcher.HandleAsync<List<DomainModelDto>?>(query);
        }
    }
}