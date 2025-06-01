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
        public Language Language {get; private set;}

        private Model(string name, string tag,ModelType type,int level,Language language)
        {
            TraceId = TraceId.Create();
            Name = name;
            Tag = tag;
            Type = type;
            Level = level;
            Language = language;
        }
        private Model(Guid id,string name, string tag,string type,int level,Language language)
        {
            TraceId = TraceId.Load(id);
            Name = name;
            Tag = tag;
            Type = ModelType.Create(type);
            Level = level;
            Language = language;
        }
        internal static IActionResult<Model> Create(string name,string tag, ModelAbstractions abstraction,int level,Language language) 
        {            
            if(string.IsNullOrEmpty(name))
                return TheAction.Failed<Model>("The name should not be null or empty");

            if(string.IsNullOrEmpty(tag))
                return TheAction.IsDone<Model>(new Model(name,"",ModelType.Create(abstraction),level,language));

            return TheAction.IsDone<Model>(new Model(name,tag,ModelType.Create(abstraction),level,language));
        }
        public static Model Load(Guid id,string name,string tag, string type,int level,Language language){
            ModelType modelType = ModelType.Create(type);
            return new Model(id,name,tag,type,level,language);
        }      
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Tag;
            yield return Type;
            yield return Level;
            yield return Language;
        }
    }
}