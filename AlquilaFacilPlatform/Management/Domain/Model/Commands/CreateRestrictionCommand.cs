namespace AlquilaFacilPlatform.Management.Domain.Model.Commands;

public record CreateRestrictionCommand(int LocalId, double NoiseLevel, bool SmokeDetection, string RestrictedLocation);