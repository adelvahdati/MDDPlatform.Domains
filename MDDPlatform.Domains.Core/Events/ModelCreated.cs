using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.Domains.Core.Events
{
    public class ModelCreated : IDomainEvent
    {
        public Guid DomainId {get;}
        public Guid ModelId {get;}
        public string Name {get;}
        public string Tag {get;}
        public string Type {get;}
        public int Level {get;}
        public Guid LanguageId {get;}
        internal ModelCreated(Guid domainId , Model model)
        {
            DomainId = domainId;
            ModelId = model.TraceId.Value;
            Name = model.Name;
            Tag = model.Tag;
            Type = model.Type.Value;
            Level = model.Level;
            LanguageId = model.Language.Id;
        }
    }
}