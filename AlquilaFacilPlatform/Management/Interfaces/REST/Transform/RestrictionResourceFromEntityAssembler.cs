using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class RestrictionResourceFromEntityAssembler
{
    public static RestrictionResource ToResourceFromEntity(Restriction restriction)
    {
        return new RestrictionResource(
            restriction.Id,
            restriction.LocalId,
            restriction.NoiseLevel,
            restriction.SmokeDetection,
            restriction.RestrictedLocation
        );
    }
}