
using MDDPlatform.Messages.Commands;
namespace MDDPlatform.Domains.Services.Commands;
public class CreatePackageFromDomain : ICommand
{
    public string Title {get;set;}
    public Guid DomainId {get;set;}

    public CreatePackageFromDomain(string title, Guid domainId)
    {
        Title = title;
        DomainId = domainId;
    }
}

