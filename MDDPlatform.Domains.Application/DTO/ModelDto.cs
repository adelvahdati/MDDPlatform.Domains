namespace MDDPlatform.Domains.Application.DTO
{
    public class ModelDto{
        public Guid Id {get;set;}
        public string Name { get;set; }
        public string Tag { get;set; }
        public ModelDto(Guid id, string name, string tag)
        {
            Id = id;
            Name = name;
            Tag = tag;
        }
        public ModelDto()
        {
            Id = Guid.Empty;
            Name = "";
            Tag = "";
        }        
    }


}