using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Application.Internal.CommandServices;

public class SeedSensorStateCommandService(ISensorStateRepository repository, IUnitOfWork unitOfWork): ISeedSensorStateCommandService
{
    public async Task Handle(SeedSensorStatesCommand command)
    {
        foreach (ESensorStates state in Enum.GetValues(typeof(ESensorStates)))
        {
            if (await repository.ExistsSensorState(state)) continue;
            var sensorState = new SensorState(state.ToString());
            await repository.AddAsync(sensorState);
        }

        await unitOfWork.CompleteAsync();
    }
}