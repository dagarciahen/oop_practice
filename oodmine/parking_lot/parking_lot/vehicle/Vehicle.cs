namespace vehicle;

public interface IVehicle
{
    string getLicensePlate();
    string getVehicleSize();
}
public abstract class Vehicle : IVehicle
{
    public abstract string getLicensePlate();
    public abstract string getVehicleSize();
}