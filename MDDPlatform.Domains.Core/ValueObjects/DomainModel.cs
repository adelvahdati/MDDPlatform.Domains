using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Domains.Core.ValueObjects
{
    public class DomainModel : ValueObject
    {
        public string Name { get; private set; }
        public string Tag { get; private set; }

        private DomainModel(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }
        internal static IActionResult<DomainModel> Create(string name,string tag) 
        {            
            if(string.IsNullOrEmpty(name))
                return TheAction.Failed<DomainModel>("The name should not be null or empty");

            if(string.IsNullOrEmpty(tag))
                return TheAction.IsDone<DomainModel>(new DomainModel(name,""));

            return TheAction.IsDone<DomainModel>(new DomainModel(name,tag));
        }      
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Tag;
        }
    }
}