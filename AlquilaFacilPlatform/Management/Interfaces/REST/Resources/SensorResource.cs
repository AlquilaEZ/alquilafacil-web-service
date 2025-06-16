namespace AlquilaFacilPlatform.Management.Interfaces.REST.Resources;

public record SensorResource(int Id, string Code, string Type, string State, string Location, int LocalId);