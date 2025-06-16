using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Management.Domain.Model.Entities;

public class Reading
{
    public Reading()
    {
        SensorId = 0;
        Timestamp = DateTime.MinValue;
        Value = new ReadingValue();
        Unit = new ReadingUnit();
    }
    
    public Reading(int sensorId, DateTime timestamp, string value, string unit)
    {
        SensorId = sensorId;
        Timestamp = timestamp;
        Value = new ReadingValue(value);
        Unit = new ReadingUnit(unit);
    }

    public Reading(CreateReadingCommand command)
    {
        SensorId = command.SensorId;
        Timestamp = command.Timestamp;
        Value = new ReadingValue(command.Value);
        Unit = new ReadingUnit(command.Unit);
    }

    public int Id { get; set; }
    public int SensorId { get; set; }
    public DateTime Timestamp { get; set; }
    public ReadingValue Value { get; private set; }
    public ReadingUnit Unit { get; private set; }
    public string ReadingValue => Value.Value;
    public string ReadingUnit => Unit.Unit;
}