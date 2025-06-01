using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Application.DTO;
public class LanguageDto {
    public Guid Id {get; set;}
    public string Name {get;  set;}
    public bool IsBuiltin {get;set;}
    public LanguageDto( Guid id, string name,bool isBuiltin)
    {
        this.Id = id;
        this.Name = name;
        IsBuiltin = isBuiltin;
    }
    public static LanguageDto CreateFrom(Language language){
        return new LanguageDto(language.Id,language.Name,language.IsBuiltin);
    }
}