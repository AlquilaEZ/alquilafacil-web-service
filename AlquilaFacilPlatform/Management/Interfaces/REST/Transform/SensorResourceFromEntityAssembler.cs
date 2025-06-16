using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Management.Interfaces.REST.Transform;

public static class SensorResourceFromEntityAssembler
{
    public static SensorResource ToResourceFromEntity(Sensor sensor)
    {
        return new SensorResource(
            sensor.Id,
            sensor.SensorCode,
            sensor.SensorType,
            sensor.SensorState,
            sensor.Location.LocalLocation,
            sensor.LocalId
        );
    }
}