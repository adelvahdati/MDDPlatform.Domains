namespace MDDPlatform.Domains.Application.DTO{
    public class DomainModelDto{
        public Guid Id {get;set;}
        public string Name { get;set; }
        public string Tag { get;set; }
        public Guid DomainId {get;set;}

        public DomainModelDto(Guid id, string name, string tag,Guid domainId )
        {            
            Id = id;
            Name = name;
            Tag = tag;
            DomainId = domainId;
        }
    }
}