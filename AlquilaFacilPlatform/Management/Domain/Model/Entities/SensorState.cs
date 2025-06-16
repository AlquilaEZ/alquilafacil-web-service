namespace AlquilaFacilPlatform.Management.Domain.Model.Entities;

public class SensorState
{
    public SensorState()
    {
        State = String.Empty;
    }
    
    public SensorState(string state)
    {
        State = state;
    }
    
    public int Id { get; set; }
    public string State { get; set; }
}