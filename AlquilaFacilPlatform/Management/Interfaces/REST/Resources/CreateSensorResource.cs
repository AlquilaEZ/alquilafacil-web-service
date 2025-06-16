namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record CreateSensorResource(string SensorCode, int SensorTypeId, string Location, int LocalId);