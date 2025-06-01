using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Application.Services;
using MDDPlatform.Messages.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.Domains.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DomainController : ControllerBase{
        private readonly IDomainService _domainService;
        private readonly IMessageDispatcher _messageDispatcher;
        public DomainController(IDomainService domainService, IMessageDispatcher messageDispatcher)
        {
            _domainService = domainService;
            _messageDispatcher = messageDispatcher;
        }

        [HttpPost("{domainId:guid}/Model/Create")]
        public async Task Create(Guid domainId, [FromBody] NewModelDto model){
            await _domainService.CreateModelAsync(domainId,model);            
        }
        [HttpDelete("{domainId:guid}/Model/{modelId:guid}")]
        public async Task DeleteModel(Guid domainId,Guid modelId)
        {
            await _domainService.DeleteModelAsync(domainId,modelId);
        }

        [HttpGet("{domainId:guid}")]
        public async Task<DomainDto?> GetDomain(Guid domainId){
            var domain = await _domainService.GetDomainAsync(domainId);
            return domain;
        }

        [HttpGet("{domainId:guid}/Models")]
        public async Task<List<ModelDto>> GetDomainModels(Guid domainId){
            return await _domainService.GetDomainModelsAsync(domainId);
        }

        [HttpGet("{domainId:guid}/Model/{modelId}")]
        public async Task<ModelDto?> FindModelById(Guid domainId,Guid modelId)
        {
            return await _domainService.FindModelByIdAsync(domainId,modelId);
        }
        [HttpGet("DomainModel/{modelId}")]
        public async Task<DomainModelDto?> FindDomainModelById(Guid modelId)
        {
            return await _domainService.FindDomainModelByIdAsync(modelId);
        }
        [HttpPost("DomainModels")]
        public async Task<List<DomainModelDto>?> FindDomainModels(FindDomainModelsById query)
        {
            return await _domainService.FindDomainModelsByIdAsync(query.ModelIds);
        }
        [HttpGet("ProblemDomainModels/{problemDomainId}")]
        public async Task<List<ModelDto>> GetProblemDomainModels(Guid problemDomainId)
        {
            return await _domainService.GetProblemDomainModelsAsync(problemDomainId);
        }
        [HttpPost("Find")]
        public async Task<List<ModelDto>> SearchInModels(FindModels query)
        {
            return await _messageDispatcher.HandleAsync<List<ModelDto>>(query);
        }
    }
}