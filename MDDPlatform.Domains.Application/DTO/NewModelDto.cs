namespace MDDPlatform.Domains.Application.DTO
{
    public class NewModelDto
    {
        public string Name { get;set; }
        public string Tag { get;set; }
        
        public NewModelDto(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }
    }
}