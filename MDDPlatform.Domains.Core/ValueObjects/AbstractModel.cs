using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Domains.Core.ValueObjects;
public class ModelTemplate : ValueObject
{
    public string NameExpression { get; private set; }
    public string TagExpression { get; private set; }
    public ModelType Type {get;private set;}
    public int Level {get; private set;}
    public Language Language {get; private set;}

    public ModelTemplate(string nameExpression, string tagExpression, ModelType type, int level, Language language)
    {
        NameExpression = nameExpression;
        TagExpression = tagExpression;
        Type = type;
        Level = level;
        Language = language;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return NameExpression;
        yield return TagExpression;
        yield return Type;
        yield return Level;
        yield return Language;
    }
}
