using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Core.Entities;

public class Package : BaseEntity<Guid>
{
    private readonly List<ModelTemplate> _modelTemplate;
    public string Title { get; private set; }
    public IReadOnlyList<ModelTemplate> ModelTemplates => _modelTemplate;

    public Package(string title, List<ModelTemplate> modelTemplate)
    {
        Id = Guid.NewGuid();
        _modelTemplate = modelTemplate;
        Title = title;
    }
    public Package(Guid id,string title, List<ModelTemplate> modelTemplate)
    {
        Id = id;
        _modelTemplate = modelTemplate;
        Title = title;
    }
    public static Package CreateFrom(Domain domain , string title)
    {
        var abstractModels = domain.Models.Select(model=> new ModelTemplate(model.Name,model.Tag,model.Type,model.Level,model.Language)).ToList();
        return new Package(title,abstractModels);
    }
}