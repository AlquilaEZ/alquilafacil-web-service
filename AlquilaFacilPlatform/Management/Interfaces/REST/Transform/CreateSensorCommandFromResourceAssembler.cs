using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class CreateSensorCommandFromResourceAssembler
{
    public static CreateSensorCommand ToCommandFromResource(CreateSensorResource resource)
    {
        return new CreateSensorCommand(
            resource.SensorCode,
            resource.SensorTypeId,
            resource.Location,
            resource.LocalId
        );
    }
}