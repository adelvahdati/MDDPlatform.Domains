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
            await _domainService.CreateModel(domainId,model);            
        }

        [HttpGet("{domainId}")]
        public async Task<DomainDto> GetDomain(Guid domainId){
            return await _domainService.GetDomain(domainId);
        }

        [HttpGet("{domainId}/Models")]
        public async Task<IList<ModelDto>> GetModels(Guid domainId){
            return await _domainService.GetModels(domainId);
        }

        [HttpGet("{domainId}/Models/{name}")]
        public async Task<IList<ModelDto>> GetModels(Guid domainId,string name){
            return await _domainService.GetModels(domainId,name);
        }

        [HttpGet("{domainId}/Find/{name}/{tag}")]
        public async Task<ModelDto> GetModelByNameTag(Guid domainId,string name,string tag){
            Console.WriteLine($"Find By name & tag : {domainId} - {name} - {tag}");

            return await _domainService.GetModel(domainId,name,tag);
        }
        
        [HttpGet("{domainId}/Find/{name}")]
        public async Task<ModelDto> GetModelByName(Guid domainId,string name){
            Console.WriteLine($"Find By name : {domainId} - {name} ");

            return await _domainService.GetModel(domainId,name,"");
            
        }
    }
}