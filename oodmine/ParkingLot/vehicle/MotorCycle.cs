namespace vehicle;

public class MotorCycle : Vehicle
{
    private string _licensePlate;

    public MotorCycle(string licensePlate)
    {
        _licensePlate = licensePlate;
    }

    public override string licensePlate => _licensePlate;
    public override VehicleSize getVehicleSize() 
    {
        return VehicleSize.SMALL;

    }





}