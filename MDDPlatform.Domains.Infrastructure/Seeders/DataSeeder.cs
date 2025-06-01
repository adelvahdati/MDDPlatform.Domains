using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Services.Repositories;

namespace MDDPlatform.Domains.Infrastructure.Seeders;
public class DataSeeder : IDataSeeder
{
    private readonly IPackageRepository _packageReposity;

    public DataSeeder(IPackageRepository packageReposity)
    {
        _packageReposity = packageReposity;
    }

    public async Task SeedPackageAsync()
    {
        var templates = new List<ModelTemplate>();
        // CIM        
        var cracModel = new ModelTemplate("01- +Domain.Name+ – CRAC Model","CRAC",ModelType.CIM(),1,CRACLanguage());
        var cimModel = new ModelTemplate("02- +Domain.Name+ – CIM Model","CIM",ModelType.CIM(),1,CIMLanguage());
        var cimConcepts = new ModelTemplate("03- +Domain.Name+ – CIM Concepts","Built-in",ModelType.CIM(),1,BaseConceptLanguage());


        // PIM
        var cqrs = new ModelTemplate("04- +Domain.Name+ – CQRS Model","CQRS", ModelType.PIM(),1,CQRSLanguage());
        var cqrsConcept = new ModelTemplate("05- +Domain.Name+ – CQRS Concepts","Built-in",ModelType.PIM(),1,BaseConceptLanguage());        

        var controller = new ModelTemplate("06- +Domain.Name+ – Controller Model","Controller",ModelType.PIM(),1,ApiControllerLanguage());
        var controllerConcept = new ModelTemplate("07- +Domain.Name+ – Controller Concepts","Built-in",ModelType.PIM(),1,BaseConceptLanguage());

        var corDomain = new ModelTemplate("08- +Domain.Name+ – Core Domain Model","CoreDomain",ModelType.PIM(),1,CoreDomainLanguage());
        var coreDomainConcept = new ModelTemplate("09- +Domain.Name+ – Core Domain Concepts","Built-in",ModelType.PIM(),1,BaseConceptLanguage());



        // PSM
        var cqrsClasses = new ModelTemplate("10- +Domain.Name+ – CQRS Classes","Classes",ModelType.PSM(),1,ClassLanguage());
        var cqrsClassConcept = new ModelTemplate("11- +Domain.Name+ – CQRS Class Concepts","Built-in",ModelType.PSM(),1,BaseConceptLanguage());

        var controllerClasses = new ModelTemplate("12- +Domain.Name+ – Controller Classes","Classes",ModelType.PSM(),1,ClassLanguage());
        var controllerClassConcept = new ModelTemplate("13- +Domain.Name+ – Controller Class Concepts","Built-in",ModelType.PSM(),1,BaseConceptLanguage());

        var coreDomainClasses = new ModelTemplate("14- +Domain.Name+ – Core Domain Classes","Classes",ModelType.PSM(),1,ClassLanguage());
        var coreDomainClassConcept = new ModelTemplate("15- +Domain.Name+ – Core Domain Class Concepts","Built-in",ModelType.PSM(),1,BaseConceptLanguage());



        // Code
        var dotnetProject = new ModelTemplate("16- +Domain.Name+ Project Settings & Dependencies",".Net Core",ModelType.Code(),1,DotNetProjectLanguage());
        var projectClassFiles = new ModelTemplate("17- +Domain.Name+ Project Files - Classes","Project Code",ModelType.Code(),1,CodeFilesLanguage());
        var projectInterfaceFiles = new ModelTemplate("18- +Domain.Name+ Project Files - Interfaces","Project Code",ModelType.Code(),1,CodeFilesLanguage());
        var projectSolutionFiles = new ModelTemplate("19- +Domain.Name+ Project Solution","Project Code",ModelType.Code(),1,CodeFilesLanguage());

        templates.AddRange(new[]{
            cracModel,
            cimModel,
            cimConcepts,
            cqrs,
            cqrsConcept,
            controller,
            controllerConcept,
            coreDomainClassConcept,
            coreDomainConcept,
            cqrsClasses,
            cqrsClassConcept,
            controllerClasses,
            controllerClassConcept,
            coreDomainClasses,
            coreDomainClassConcept,
            dotnetProject,
            projectClassFiles,
            projectInterfaceFiles,
            projectSolutionFiles
        });

        var title = "Models in MDA Abstraction Layers";
        var id = Guid.Parse("ec5494b4-cc9e-4f8e-b132-bce6d8b90410");
        var package = new Package(id,title,templates);

        await _packageReposity.CreateOrUpdatePackageAsync(package);
    }
    private Language CRACLanguage()
    {
        Guid languageId = Guid.Parse("ef71faaf-61ad-4657-8d5c-d06c008e347d");
        string name = "CRAC Metamodel";
        return new Language(languageId,name);
       
    }
    private Language CIMLanguage(){
        Guid languageId = Guid.Parse("ecb988fe-f4cd-41d9-8080-598fdcb381d6");
        string name = "CIM Metamodel";
        return new Language(languageId,name);

    }
    private Language CoreDomainLanguage(){
        Guid languageId = Guid.Parse("46a35010-6498-41e1-b791-39871fa04e64");
        string name = "Core Domain";
        return new Language(languageId,name);

    }
    private Language DDDLanguage()
    {
        Guid languageId = Guid.Parse("098d8f76-b9d7-45ee-b51f-56a84f6f26e2");
        string name = "Domain-Driven Design";
        return new Language(languageId,name);

    }
    private Language CQRSLanguage()
    {
        Guid languageId = Guid.Parse("fa217ba5-4a97-4087-ab03-512ec6404503");
        string name = "CQRS";
        return new Language(languageId,name);

    }
    private Language RepositoryLanguage()
    {
        Guid languageId = Guid.Parse("67ccb3ed-c48c-454a-95f8-d6f4c3d786c2");
        string name = "Repositories";
        return new Language(languageId,name);

    }
    private Language ApiControllerLanguage()
    {
        Guid languageId = Guid.Parse("e7a55030-5fa1-47b1-b4f5-23eca4511830");
        string name = "Api Controllers";
        return new Language(languageId,name);
    }
    private Language ServiceLanguage()
    {
        Guid languageId = Guid.Parse("0f72d306-86c1-4a38-ac4b-49f1ca28ea1c");
        string name = "Services";
        return new Language(languageId,name);

    }
    private Language InterfaceLanguage()
    {
        Guid languageId = Guid.Parse("ba98ac39-1577-4088-9014-3f0f470e1d9a");
        string name = "Interfaces";
        return new Language(languageId,name);

    }
    private Language DatabaseLanguage()
    {
        Guid languageId = Guid.Parse("fa012f4a-bcb9-4fc2-bd8a-18c7292e2e24");
        string name = "Databases";
        return new Language(languageId,name);

    }
    private Language DotNetProjectLanguage()
    {
        Guid languageId = Guid.Parse("d229d152-92be-4398-8017-8d9c6b483312");
        string name = ".Net Core Project";
        return new Language(languageId,name);

    }
    private Language ClassLanguage()
    {
        Guid languageId = Guid.Parse("6cfe4311-b045-4058-b2e1-cf857ca4a99b");
        string name = "Classes & Interfaces";
        return new Language(languageId,name);

    }
    private Language CodeFilesLanguage()
    {
        Guid languageId = Guid.Parse("a15f45e4-ced2-4c87-a0a3-06371f62b50c");
        string name = "Project Code Metamodel";
        return new Language(languageId,name);
    }
    private Language BaseConceptLanguage(){
        Guid languageId = Guid.Empty;
        string name = "BaseConcept (Built-in)";
        return new Language(languageId,name);

    }
}