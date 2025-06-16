namespace AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

public record ReadingUnit(string Unit)
{
    public ReadingUnit() : this(string.Empty)
    {
        
    }
}