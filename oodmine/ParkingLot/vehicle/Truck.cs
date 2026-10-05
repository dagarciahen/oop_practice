namespace vehicle;

public class Truck : Vehicle
{
    string _licensePlate;
    public Truck(string licensePlate)
    {
        _licensePlate = licensePlate;
    }

    public override string licensePlate => _licensePlate;
    public override VehicleSize getVehicleSize()
    {
        return VehicleSize.LARGE;
    }

    

}