namespace vehicle;

public class Car : Vehicle
{
    private string _licensePlate;

    public Car(string licensePlate)
    {
        _licensePlate = licensePlate;
    }

    public override string licensePlate => _licensePlate;

    public override VehicleSize getVehicleSize()
    {
        return VehicleSize.MEDIUM;
    }
}