using MDDPlatform.Domains.Core.Entities;

namespace MDDPlatform.Domains.Application.DTO;
public class PackageDto
{
    public Guid Id {get;set;}
    public string  Title {get;set;}
    public List<ModelTemplateDto> ModelTemplates {get;set;}

    public PackageDto(Guid id, string title, List<ModelTemplateDto> abstractModels)
    {
        Id = id;
        Title = title;
        ModelTemplates = abstractModels;
    }

    internal static PackageDto CreateFrom(Package package)
    {
        var id = package.Id;
        var title = package.Title;
        var abstractModelsDto =  package.ModelTemplates.Select(modelTemplate=> ModelTemplateDto.CreateFrom(modelTemplate)).ToList();
        return new PackageDto(id,title,abstractModelsDto);
    }
}