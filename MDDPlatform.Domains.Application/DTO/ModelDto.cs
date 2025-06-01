using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Application.DTO
{
    public class ModelDto{
        public Guid Id {get;set;}
        public string Name { get;set; }
        public string Tag { get;set; }
        public string Type {get;set;}
        public int Level {get;set;}
        public LanguageDto Language {get;set;}
        public ModelDto(Guid id, string name, string tag, string type, int level,LanguageDto language)
        {
            Id = id;
            Name = name;
            Tag = tag;
            Type = type;
            Level = level;
            Language = language;
        }

        internal static ModelDto CreateFrom(Model model)
        {
            return new ModelDto(model.TraceId.Value,
                                model.Name,
                                model.Tag,
                                model.Type.Value,
                                model.Level,
                                LanguageDto.CreateFrom(model.Language));
        }
    }


}