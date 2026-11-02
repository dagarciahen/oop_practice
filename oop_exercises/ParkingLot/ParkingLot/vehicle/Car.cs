namespace vehicle;

public class Car : Vehicle
{
    private readonly string _licensePlate;
    
    public Car(string licensePlate)
    {
        _licensePlate = licensePlate;
    }
    public override string getLicensePlate()
    {
        return _licensePlate;
    }
    public override VehicleSize getVehicleSize()
    {
        return VehicleSize.MEDIUM;
    }
}