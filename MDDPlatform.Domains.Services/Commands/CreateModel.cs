using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.Messages.Commands;

namespace MDDPlatform.Domains.Services.Commands
{
    public class CreateModel : ICommand
    {
        public Guid DomainId{ get;}    
        public string Name {get;}
        public string Tag { get;}
        public ModelAbstractions Abstraction {get;}
        public int Level {get;}
        public CreateModel(Guid domainId, string name, string tag,ModelAbstractions abstraction,int level)
        {
            DomainId = domainId;
            Name = name;
            Tag = tag;
            Abstraction =abstraction;
            Level = level;
        }
    }
}