using vehicle;

namespace spot;

public interface IParkingSpot
{
    int SpotNumber {get;}
    Vehicle SpotSize {get;}
    bool isAvailable();
    void occupy(Vehicle vehicle);
    void vaccate();



}
public abstract class ParkingSpot
{
    public abstract int SpotNumber {get;}
    public abstract VehicleSize SpotSize {get;}
    public abstract bool isAvailable();
    public abstract void occupy(Vehicle vehicle);
    public abstract void vaccate();


}