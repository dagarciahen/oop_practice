namespace vehicle;

public class MotorCycle : Vehicle
{
    private readonly string _licensePlate;
    public MotorCycle(string licensePlate)
    {
        _licensePlate = licensePlate;
    }
    
    public override string getLicensePlate()
    {
        return _licensePlate; 
    }

    public override VehicleSize getVehicleSize()
    {
        return VehicleSize.LARGE;
    }

}