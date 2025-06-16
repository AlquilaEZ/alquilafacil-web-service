using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;

namespace AlquilaFacilPlatform.Management.Application.Internal.QueryServices;

public class SensorQueryService(ISensorRepository sensorRepository, IReadingRepository readingRepository): ISensorQueryService
{
    public async Task<Sensor?> Handle(GetSensorByIdQuery query)
    {
        return await sensorRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Sensor>> Handle(GetAllSensorsByLocalIdQuery query)
    {
        return await sensorRepository.FindAllByLocalId(query.LocalId);
    }

    public async Task<IEnumerable<Reading>> Handle(GetAllReadingsBySensorIdQuery query)
    {
        return await readingRepository.FindAllBySensorId(query.SensorId);
    }
}