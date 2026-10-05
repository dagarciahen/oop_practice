using vehicle;
namespace spot;

public interface IParkingSpot
{
    public bool isAvailable();
    public void vaccate();
    public void occupy(Vehicle vehicle);
    public VehicleSize spotSize {get;}

}

public abstract class ParkingSpot : IParkingSpot
{    
    public abstract bool isAvailable();
    public abstract void vaccate();
    public abstract void occupy(Vehicle vehicle);
    public abstract VehicleSize spotSize {get;}
    public abstract int getSpotNumber();
}