using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Management.Domain.Services;

public interface ISensorQueryService
{
    Task<Sensor?> Handle(GetSensorByIdQuery query);
    Task<IEnumerable<Sensor>> Handle(GetAllSensorsByLocalIdQuery query);
    Task<IEnumerable<Reading>> Handle(GetAllReadingsBySensorIdQuery query);
}