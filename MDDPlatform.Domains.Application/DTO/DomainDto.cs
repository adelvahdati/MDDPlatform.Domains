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
    }
}