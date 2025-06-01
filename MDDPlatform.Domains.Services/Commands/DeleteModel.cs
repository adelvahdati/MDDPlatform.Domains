using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands;
public class DeleteModel : ICommand{
    public Guid DomainId {get;set;}
    public Guid ModelId {get;set;}

    public DeleteModel(Guid domainId, Guid modelId)
    {
        DomainId = domainId;
        ModelId = modelId;
    }
}