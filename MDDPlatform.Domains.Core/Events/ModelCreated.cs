using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.Domains.Core.Events
{
    public class ModelCreated : IDomainEvent
    {
        public Guid DomainId {get;}
        //public Guid ModelId {get;}
        public string Name {get;}
        public string Tag {get;}
        internal ModelCreated(Guid domainId , DomainModel model)
        {
            DomainId = domainId;
            //ModelId = model.Id;
            Name = model.Name;
            Tag = model.Tag;
        }
    }
}