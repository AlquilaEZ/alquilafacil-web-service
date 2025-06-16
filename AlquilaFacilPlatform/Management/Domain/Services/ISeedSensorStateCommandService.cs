using AlquilaFacilPlatform.Management.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Management.Domain.Services;

public interface ISeedSensorStateCommandService
{
    Task Handle(SeedSensorStatesCommand command);
}