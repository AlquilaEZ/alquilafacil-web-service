using AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Management.Domain.Model.Commands;

public record CreateSensorCommand(string SensorCode, int SensorTypeId, string Location, int LocalId);