using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Domains.Core.ValueObjects;
public class Language : ValueObject
{
    public Guid Id {get;private set;}
    public string Name {get; private set;}
    public bool IsBuiltin => Id == Guid.Empty;
    public Language(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
    }
}