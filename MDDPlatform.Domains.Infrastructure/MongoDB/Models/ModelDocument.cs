using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Infrastructure.MongoDB.Models;
public class ModelDocument
{
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Tag {get;set;}
        public string Type {get;set;}
        public int Level {get;set;}
        public Guid LanguageId {get;set;}
        public string LanguageName {get;set;}

    protected ModelDocument(Guid id, string name, string tag, string type, int level,Guid languageId,string languageName)
    {
        Id = id;
        Name = name;
        Tag = tag;
        Type = type;
        Level = level;
        LanguageId = languageId;
        LanguageName = languageName;
    }
    public static ModelDocument CreateFrom(Model model){
        return new ModelDocument(model.TraceId.Value,
                                    model.Name,
                                    model.Tag,
                                    model.Type.Value,
                                    model.Level,
                                    model.Language.Id,
                                    model.Language.Name);
    }
    public Model ToModel(){
        return Model.Load(Id,Name,Tag,Type,Level,new Language(LanguageId,LanguageName));
    }

    internal ModelDto ToDto()
    {
        bool isBuiltin = LanguageId == Guid.Empty;
        LanguageDto language = new LanguageDto(LanguageId,LanguageName,isBuiltin);
        return new ModelDto(Id,Name,Tag,Type,Level,language);
    }
}