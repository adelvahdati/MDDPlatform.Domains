using MDDPlatform.Domains.Application.DTO;

namespace MDDPlatform.Domains.Infrastructure.Data.Models
{
    public class DomainModelData
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Tag {get;set;}

        public DomainData Domain {get;set;}

        internal ModelDto ToDto()
        {
            return new ModelDto(Id,Name,Tag);
        }
    }
}