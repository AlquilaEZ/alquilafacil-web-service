namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record RestrictionResource(int Id, int LocalId, double NoiseLevel, bool SmokeDetection, string RestrictedLocation);