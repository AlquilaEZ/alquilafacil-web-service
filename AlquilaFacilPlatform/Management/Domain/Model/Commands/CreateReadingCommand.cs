namespace AlquilaFacilPlatform.Management.Domain.Model.Commands;

public record CreateReadingCommand(int SensorId, DateTime Timestamp, string Value, string Unit);