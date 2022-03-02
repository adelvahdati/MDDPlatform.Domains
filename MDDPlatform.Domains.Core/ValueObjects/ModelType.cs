using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.DomainModels.Core.ValueObjects
{
    public class ModelType : ValueObject
    {
        public string Value {get;}
        private ModelType(string value)
        {
            Value = value;
        }
        public static ModelType CIM(){
            return new ModelType("CIM");
        }
        public static ModelType PIM(){
            return new ModelType("PIM");
        }
        public static ModelType PSM(){
            return new ModelType("PSM");
        }
        public static ModelType Code(){
            return new ModelType("Code");
        }
        public static ModelType Undefined(){
            return new ModelType("Undefined");
        }
        public static ModelType Create(ModelAbstractions abstraction){
            if(abstraction== ModelAbstractions.CIM)
                return CIM();
            if(abstraction== ModelAbstractions.PIM)
                return PIM();
            if(abstraction== ModelAbstractions.PSM)
                return PSM();
            if(abstraction== ModelAbstractions.Code)
                return Code();
            return Undefined();
        }
        public static ModelType Create(string type){
            if(type== "CIM")
                return CIM();
            if(type== "PIM")
                return PIM();
            if(type== "PSM")
                return PSM();
            if(type=="Code")
                return Code();

            return Undefined();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}