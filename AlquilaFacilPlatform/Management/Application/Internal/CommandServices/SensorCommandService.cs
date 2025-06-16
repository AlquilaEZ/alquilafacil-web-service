using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Shared.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Application.Internal.CommandServices;

public class SensorCommandService(
    ISensorRepository sensorRepository,
    IReadingRepository readingRepository,
    ISensorTypeRepository sensorTypeRepository,
    ILocalExternalService localExternalService,
    IUnitOfWork unitOfWork
    ): ISensorCommandService
{
    public async Task<Sensor?> Handle(CreateSensorCommand command)
    {
        var localExists = await localExternalService.LocalExists(command.LocalId);
        if (!localExists)
        {
            throw new Exception("Local does not exist");
        }
        var sensorType = await sensorTypeRepository.FindByIdAsync(command.SensorTypeId);
        if (sensorType == null)
        {
            throw new Exception("Sensor type not found");
        }
        var sensor = new Sensor(command);
        await sensorRepository.AddAsync(sensor);
        await unitOfWork.CompleteAsync();
        return sensor;
    }

    public async Task<Sensor?> Handle(UpdateSensorCommand command)
    {
        var sensor = await sensorRepository.FindByIdAsync(command.Id);
        if (sensor == null)
        {
            throw new Exception("Sensor not found");
        }
        sensor.Update(command);
        sensorRepository.Update(sensor);
        await unitOfWork.CompleteAsync();
        return sensor;
    }

    public async Task<Reading?> Handle(CreateReadingCommand command)
    {
        var sensor = await sensorRepository.FindByIdAsync(command.SensorId);
        if (sensor == null)
        {
            throw new Exception("Sensor not found");
        }
        var reading = new Reading(command);
        await readingRepository.AddAsync(reading);
        await unitOfWork.CompleteAsync();
        return reading;
    }
}