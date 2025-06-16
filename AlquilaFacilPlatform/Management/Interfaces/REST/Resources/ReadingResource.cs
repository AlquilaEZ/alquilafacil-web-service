namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record ReadingResource(int Id, int SensorId, DateTime Timestamp, string Value, string Unit);