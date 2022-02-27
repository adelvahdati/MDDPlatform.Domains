using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Infrastructure.Data.Models
{
    public class DomainData : BaseEntity<Guid>{
        public string Name {get;set;}
        public ProblemDomain ProblemDomain {get;set;}
        public List<DomainModelData> DomainModels {get;set;}

        internal DomainDto ToDto()
        {
            List<ModelDto> models = new List<ModelDto>();
            foreach(var model in DomainModels){
                models.Add(model.ToDto());
            }
            return new DomainDto(Id,Name,ProblemDomain.Id,models);
        }
    }
    
}