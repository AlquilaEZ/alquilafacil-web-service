using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class UpdateSensorCommandFromResourceAssembler
{
    public static UpdateSensorCommand ToCommandFromResource(UpdateSensorResource resource)
    {
        return new UpdateSensorCommand(
            resource.Id,
            resource.SensorStateId
        );
    }
}