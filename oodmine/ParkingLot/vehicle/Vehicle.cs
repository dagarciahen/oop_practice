namespace vehicle;

public interface IVehicle
{
    VehicleSize getVehicleSize();
    string getLicensePlate();

}
public abstract class Vehicle : IVehicle
{
    public abstract VehicleSize getVehicleSize();
    public abstract string getLicensePlate();
    
}
