namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record CreateRestrictionResource(int LocalId, double NoiseLevel, bool SmokeDetection, string RestrictedLocation);