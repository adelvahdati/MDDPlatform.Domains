using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands
{
    public class CreateModel : ICommand
    {
        public Guid DomainId{ get;}    
        public string Name {get;}
        public string Tag { get;}
        public CreateModel(Guid domainId, string name, string tag)
        {
            DomainId = domainId;
            Name = name;
            Tag = tag;
        }
    }
}