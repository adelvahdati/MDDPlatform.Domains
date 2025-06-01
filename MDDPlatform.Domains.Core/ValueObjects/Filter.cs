namespace MDDPlatform.Domains.Core.ValueObjects;
public class Filter<T>
{
    public T? Value => _value;
    public bool IsApplied => !_dontCare;
    private T? _value;
    private bool _dontCare;

    protected Filter(T? value, bool dontCare)
    {
        _value = value;
        _dontCare = dontCare;
    }

    public static Filter<T> DontCare(){
        return new Filter<T>(default,true);
    }
    public static Filter<T> Create(T value){
        if(Equals(value,null))
            return DontCare();
        
        return new Filter<T>(value,false);
    }
    public bool On(T value){
        if(_dontCare)
            return true;
        
        return Equals(value,_value);        
    }
}