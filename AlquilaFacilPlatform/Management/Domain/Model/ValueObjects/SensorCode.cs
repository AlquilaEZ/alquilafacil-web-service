namespace AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

public record SensorCode(string Code)
{
    public SensorCode() : this(string.Empty)
    {
        
    }
}