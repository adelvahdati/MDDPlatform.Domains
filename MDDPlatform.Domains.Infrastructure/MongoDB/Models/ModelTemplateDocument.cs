using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Core.ValueObjects;

namespace MDDPlatform.Domains.Infrastructure.MongoDB.Models;
public class ModelTemplateDocument
{
    public string NameExpression { get;  set; }
    public string TagExpression { get;  set; }
    public string Type {get; set;}
    public int Level {get;set;}
    public Guid LanguageId {get;set;}
    public string LanguageName {get;set;}

    protected ModelTemplateDocument(string nameExpression, string tagExpression, string type, int level, Guid languageId, string languageName)
    {
        NameExpression = nameExpression;
        TagExpression = tagExpression;
        Type = type;
        Level = level;
        LanguageId = languageId;
        LanguageName = languageName;
    }
    public static ModelTemplateDocument CreateFrom(ModelTemplate modelTemplate)
    {
        return new ModelTemplateDocument(modelTemplate.NameExpression,
                                        modelTemplate.TagExpression,
                                        modelTemplate.Type.Value,
                                        modelTemplate.Level,
                                        modelTemplate.Language.Id,
                                        modelTemplate.Language.Name);
    }
    public ModelTemplate ToModelTemplate(){
        return new ModelTemplate(NameExpression,
                                TagExpression,
                                ModelType.Create(Type),
                                Level,
                                new Language(LanguageId,LanguageName));
    }
}