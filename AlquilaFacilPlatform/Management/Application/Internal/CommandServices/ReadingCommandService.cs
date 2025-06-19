using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Shared.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Application.Internal.CommandServices;

public class ReadingCommandService(
    IReadingRepository readingRepository,
    ISensorTypeRepository sensorTypeRepository,
    ILocalExternalService localExternalService,
    IUnitOfWork unitOfWork
    ): IReadingCommandService
{
    public async Task<Reading?> Handle(CreateReadingCommand command)
    {
        if (!await localExternalService.LocalExists(command.LocalId))
        {
            throw new Exception("Local does not exist");
        }
        var sensorType = await sensorTypeRepository.FindByIdAsync(command.SensorTypeId);
        if (sensorType == null)
        {
            throw new Exception("Sensor type not found");
        }
        var reading = new Reading(command);
        await readingRepository.AddAsync(reading);
        await unitOfWork.CompleteAsync();
        return reading;
    }
}