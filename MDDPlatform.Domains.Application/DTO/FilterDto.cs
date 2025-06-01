namespace MDDPlatform.Domains.Application.DTO;
public class FilterDto<T>
{
    public T? Value {get;set;}
    public bool IsApplied {get;set;}

    public FilterDto(T? value, bool isApplied)
    {
        Value = value;
        IsApplied = isApplied;
    }
}