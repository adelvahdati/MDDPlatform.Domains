using MDDPlatform.DomainModels.Core.Enums;

namespace MDDPlatform.Domains.Application.DTO
{
    public class NewModelDto
    {
        public string Name { get;set; }
        public string Tag { get;set; }
        public string Type {get;set;}
        public int Level {get;set;}

        public NewModelDto(string name, string tag, string type,int level)
        {
            Name = name;
            Tag = tag;
            Type = type;
            Level = level;
        }
    }
}