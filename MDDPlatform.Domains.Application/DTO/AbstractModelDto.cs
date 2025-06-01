using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Application.DTO;
public class ModelTemplateDto
{
    public string NameExpression { get; set; }
    public string TagExpression { get; set; }
    public string Type {get;set;}
    public int Level {get;set;}
    public Guid LanguageId {get; set;}
    public string LanguageName {get;set;}

    public ModelTemplateDto(string nameExpression, string tagExpression, string type, int level, Guid languageId, string languageName)
    {
        NameExpression = nameExpression;
        TagExpression = tagExpression;
        Type = type;
        Level = level;
        LanguageId = languageId;
        LanguageName = languageName;
    }

    internal static ModelTemplateDto CreateFrom(ModelTemplate modelTemplate)
    {
        return new ModelTemplateDto(modelTemplate.NameExpression,
                                    modelTemplate.TagExpression,
                                    modelTemplate.Type.Value,
                                    modelTemplate.Level,
                                    modelTemplate.Language.Id,
                                    modelTemplate.Language.Name);
    }
}