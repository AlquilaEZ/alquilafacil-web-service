namespace AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

public record Location(string LocalLocation)
{
    public Location() : this(string.Empty)
    {
        
    }
}