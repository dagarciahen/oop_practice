using vehicle;
namespace spot;

public interface IParkingSpot
{
    bool isAvailable();
    void vaccate();
    void occupy(Vehicle vehicle);
    VehicleSize spotSize {get;}
    int getSpotNumber(); 

}

public abstract class ParkingSpot : IParkingSpot
{    
    public abstract bool isAvailable();
    public abstract void vaccate();
    public abstract void occupy(Vehicle vehicle);
    public abstract VehicleSize spotSize {get;}
    public abstract int getSpotNumber();
}