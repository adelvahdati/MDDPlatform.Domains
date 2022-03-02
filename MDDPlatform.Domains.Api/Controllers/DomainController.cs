using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.Domains.Api.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class DomainController : ControllerBase{
        private readonly IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        [HttpPost("{domainId}/Model/Create")]
        public async Task Create(Guid domainId, [FromBody] NewModelDto model){
            Console.WriteLine($"{domainId} - {model.Name} - {model.Tag}");
            await _domainService.CreateModelAsync(domainId,model);            
        }

        [HttpGet("{domainId}")]
        public async Task<DomainDto> GetDomain(Guid domainId){
            return await _domainService.GetDomainAsync(domainId);
        }

        [HttpGet("{domainId}/Models")]
        public async Task<IList<ModelDto>> GetModels(Guid domainId){
            return await _domainService.GetAllModelsAsync(domainId);
        }

        [HttpGet("{domainId}/Models/{name}")]
        public async Task<IList<ModelDto>> GetModels(Guid domainId,string name,ModelAbstractions abstraction=ModelAbstractions.Undefined,int level = 0){
            return await _domainService.GetModelsByNameAsync(domainId,name,abstraction,level);
        }

        [HttpGet("{domainId}/Find/{name}/{tag}")]
        public async Task<ModelDto> GetModelByNameTag(Guid domainId,string name,string tag,ModelAbstractions abstraction=ModelAbstractions.Undefined,int level = 0){
            Console.WriteLine($"Find By name & tag : {domainId} - {name} - {tag}");

            return await _domainService.FindModelAsync(domainId,name,tag,abstraction,level);
        }
        
        [HttpGet("{domainId}/Find/{name}")]
        public async Task<ModelDto> GetModelByName(Guid domainId,string name,ModelAbstractions abstraction=ModelAbstractions.Undefined,int level = 0){
            Console.WriteLine($"Find By name : {domainId} - {name} ");
            
            return await _domainService.FindModelAsync(domainId,name,"",abstraction,level);
            
        }
    }
}