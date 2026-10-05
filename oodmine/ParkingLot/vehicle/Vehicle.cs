namespace vehicle;

public interface IVehicle
{
    public string licensePlate {get;}
    public VehicleSize getVehicleSize();

}
public abstract class Vehicle : IVehicle
{
    public abstract string licensePlate {get;}
    public abstract VehicleSize getVehicleSize();

}