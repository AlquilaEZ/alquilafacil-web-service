namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record CreateReadingResource(int SensorId, DateTime Timestamp, string Value, string Unit);