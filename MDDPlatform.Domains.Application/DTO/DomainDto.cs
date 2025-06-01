using MDDPlatform.Domains.Core.Entities;

namespace MDDPlatform.Domains.Application.DTO{
    public class DomainDto{
        public Guid Id {get;set;}
        public string Name {get;set;}
        public Guid ProblemDomainId {get;set;}
        public List<ModelDto> Models {get;set;}

        public DomainDto(Guid id, string name, Guid problemDomainId, List<ModelDto> models)
        {
            Id = id;
            Name = name;
            ProblemDomainId = problemDomainId;
            Models = models;
        }

        internal static DomainDto CreateFrom(Domain domain)
        {
            List<ModelDto> models;

            if(domain.Models.Count == 0)
                models = new List<ModelDto>();
            
            models = domain.Models.Select(model=> ModelDto.CreateFrom(model)).ToList();
            return new DomainDto(domain.Id,domain.Name,domain.ProblemDomain.Id,models);
        }
    }
}