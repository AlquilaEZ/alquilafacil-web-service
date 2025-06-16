using AlquilaFacilPlatform.Management.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Management.Domain.Model.Aggregates;

public class Restriction
{
    public Restriction()
    {
        LocalId = 0;
        NoiseLevel = 0.0;
        SmokeDetection = false;
        RestrictedLocation = string.Empty;
    }
    
    public Restriction(int localId, double noiseLevel, bool smokeDetection, string restrictedLocation)
    {
        LocalId = localId;
        NoiseLevel = noiseLevel;
        SmokeDetection = smokeDetection;
        RestrictedLocation = restrictedLocation;
    }

    public Restriction(CreateRestrictionCommand command)
    {
        LocalId = command.LocalId;
        NoiseLevel = command.NoiseLevel;
        SmokeDetection = command.SmokeDetection;
        RestrictedLocation = command.RestrictedLocation;
    }
    
    public int Id { get; private set; }
    public int LocalId { get; private set; }
    public double NoiseLevel { get; private set; }
    public bool SmokeDetection { get; private set; }
    public string RestrictedLocation { get; private set; }
}