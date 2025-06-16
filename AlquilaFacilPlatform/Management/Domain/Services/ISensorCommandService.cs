using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;

namespace AlquilaFacilPlatform.Management.Domain.Services;

public interface ISensorCommandService
{
    Task<Sensor?> Handle(CreateSensorCommand command);
    Task<Sensor?> Handle(UpdateSensorCommand command);
    Task<Reading?> Handle(CreateReadingCommand command);
}