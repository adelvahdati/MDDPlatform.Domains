using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.Domains.Core.ValueObjects
{
    public class Model : TraceableValueObject
    {
        public string Name { get; private set; }
        public string Tag { get; private set; }
        public ModelType Type {get;private set;}
        public int Level {get;set;}

        private Model(string name, string tag,ModelType type,int Level)
        {
            Name = name;
            Tag = tag;
            Type = type;
        }
        internal static IActionResult<Model> Create(string name,string tag, ModelAbstractions abstraction,int level) 
        {            
            if(string.IsNullOrEmpty(name))
                return TheAction.Failed<Model>("The name should not be null or empty");

            if(string.IsNullOrEmpty(tag))
                return TheAction.IsDone<Model>(new Model(name,"",ModelType.Create(abstraction),level));

            return TheAction.IsDone<Model>(new Model(name,tag,ModelType.Create(abstraction),level));
        }      
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Tag;
            yield return Type;
            yield return Level;
        }
    }
}