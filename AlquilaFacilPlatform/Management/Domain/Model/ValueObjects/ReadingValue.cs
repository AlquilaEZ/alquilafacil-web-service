namespace AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

public record ReadingValue(string Value)
{
    public ReadingValue() : this(string.Empty)
    {
        
    }
}