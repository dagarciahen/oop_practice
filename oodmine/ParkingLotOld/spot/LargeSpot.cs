using vehicle;
namespace spot;

public abstract class LargeSpot : ParkingSpot
{
    private int _spotNumber;
    private VehicleSize _spotSize;
    private Vehicle _vehicle;

    public LargeSpot(VehicleSize spotSize)
    {
        _spotSize = spotSize;
        _vehicle = null;
    }
    
    public override bool isAvailable()
    {
        return _vehicle == null;
    }
    
    public override void vaccate()
    {
        _vehicle = null;
    }
    
    public override void occupy(Vehicle vehicle)
    {
        _vehicle = vehicle;
    }
    

    public override VehicleSize spotSize => _spotSize;
    public override int getSpotNumber () => _spotNumber; 
}