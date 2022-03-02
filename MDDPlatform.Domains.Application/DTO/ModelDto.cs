namespace MDDPlatform.Domains.Application.DTO
{
    public class ModelDto{
        public Guid Id {get;set;}
        public string Name { get;set; }
        public string Tag { get;set; }
        public string Type {get;set;}
        public int Level {get;set;}
        public ModelDto(Guid id, string name, string tag, string type, int level)
        {
            Id = id;
            Name = name;
            Tag = tag;
            Type = type;
            Level = level;
        }
    }


}