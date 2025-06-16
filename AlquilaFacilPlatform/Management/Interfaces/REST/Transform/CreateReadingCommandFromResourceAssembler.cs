using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class CreateReadingCommandFromResourceAssembler
{
    public static CreateReadingCommand ToCommandFromResource(CreateReadingResource resource)
    {
        return new CreateReadingCommand(
            resource.SensorId,
            resource.Timestamp,
            resource.Value,
            resource.Unit
        );
    }
}