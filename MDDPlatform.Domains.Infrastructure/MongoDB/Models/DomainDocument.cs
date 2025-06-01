using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Infrastructure.MongoDB.Models;
public class DomainDocument : BaseEntity<Guid>
{
        public string Name {get;set;}
        public Guid ProblemDomainId {get;set;}
        public List<ModelDocument> Models {get;set;}

    protected DomainDocument(Guid domainId,string name, Guid problemDomainId, List<ModelDocument> models)
    {
        Id = domainId;
        Name = name;
        ProblemDomainId = problemDomainId;
        Models = models;
    }
    public static DomainDocument CreateFrom(Domain domain){
        var models = domain.Models;
        if(models.Count == 0)
            return new DomainDocument(domain.Id,domain.Name,domain.ProblemDomain.Id,new List<ModelDocument>());
        
        var modelDocs = models.Select(model=> ModelDocument.CreateFrom(model)).ToList();
        return new DomainDocument(domain.Id,domain.Name,domain.ProblemDomain.Id,modelDocs);
    }
    public Domain ToDomain(){
        var models = Models.Select(modelDoc=> modelDoc.ToModel()).ToList();
        return Domain.Load( new ProblemDomain(ProblemDomainId),Id,Name,models);
    }
}