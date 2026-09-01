using lot;

namespace spot;


public interface IParkingSpot
{
    bool occupied();
    Vehicle parkVehicle();
    void unparkVehicle();

    VehicleSize getVehicleSize();

}
public class ParkingSpot : IParkingSpot
{
    private string _spotSize;

    public ParkingSpot(string spotSize)
    {
        _spotSize = spotSize;
    }
}
