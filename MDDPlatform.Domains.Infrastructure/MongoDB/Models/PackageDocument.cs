using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Infrastructure.MongoDB.Models;
public class PackageDocument : BaseEntity<Guid>
{
    public string Title { get; set; }
    public List<ModelTemplateDocument> ModelTemplates {get;set;}

    protected PackageDocument(Guid id,string title, List<ModelTemplateDocument> modelTemplates)
    {
        Id = id;
        Title = title;
        ModelTemplates = modelTemplates;
    }

    public static PackageDocument CreateFrom(Package package)
    {
        var modelTemplatesDoc = package.ModelTemplates.Select(m=>ModelTemplateDocument.CreateFrom(m)).ToList();

        return new PackageDocument(package.Id,
                                            package.Title,
                                            modelTemplatesDoc);
    }
    public Package ToPackage()
    {
        var modelTemplates = ModelTemplates.Select(m=>m.ToModelTemplate()).ToList();
        return new Package(Id,Title,modelTemplates);
    }
}