using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Management.Domain.Model.Aggregates;

public class Sensor
{
    public Sensor()
    {
        Code = new SensorCode();
        TypeId = (int)ESensorTypes.Smoke;
        StateId = (int)ESensorStates.Active;
        Location = new Location();
        LocalId = 0;
    }
    
    public Sensor(string code, int typeId, string location, int localId)
    {
        Code = new SensorCode(code);
        TypeId = typeId;
        StateId = (int)ESensorStates.Active;
        Location = new Location(location);
        LocalId = localId;
    }

    public Sensor(CreateSensorCommand command)
    {
        Code = new SensorCode(command.SensorCode);
        TypeId = command.SensorTypeId;
        StateId = (int)ESensorStates.Active;
        Location = new Location(command.Location);
        LocalId = command.LocalId;
    }
    
    public void Update(UpdateSensorCommand command)
    {
        StateId = command.SensorStateId;
    }
    
    public int Id { get; set; }
    public SensorCode Code { get; private set; }
    public int TypeId { get; private set; }
    public int StateId { get; private set; }
    public Location Location { get; private set; }
    public int LocalId { get; set; }
    
    public string SensorCode => Code.Code;
    public string SensorLocation => Location.LocalLocation;
    public string SensorType => ((ESensorTypes)TypeId).ToString();
    public string SensorState => ((ESensorStates)StateId).ToString();
}