public interface IVehicle
{
    string LicensePlate {get;}
    VehicleSize VehicleSize {get;}
    
}


public abstract class Vehicle : IVehicle
{
    public abstract string LicensePlate {get;}
    public abstract VehicleSize VehicleSize {get;}
    
}
