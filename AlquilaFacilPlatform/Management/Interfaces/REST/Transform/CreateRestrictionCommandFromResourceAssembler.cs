using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class CreateRestrictionCommandFromResourceAssembler
{
    public static CreateRestrictionCommand ToCommandFromResource(CreateRestrictionResource resource)
    {
        return new CreateRestrictionCommand(
            resource.LocalId,
            resource.NoiseLevel,
            resource.SmokeDetection,
            resource.RestrictedLocation
        );
    }
}