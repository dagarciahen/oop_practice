using vehicle;
namespace spot;

public abstract class MediumSpot : ParkingSpot
{
    private VehicleSize _spotSize;
    private Vehicle _vehicle;
    private int _spotNumber;

    public MediumSpot(VehicleSize spotSize)
    {
        _spotSize = spotSize;
        _vehicle = null!;

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
    
    public override VehicleSize spotSize => VehicleSize.MEDIUM;
    
    public override int getSpotNumber() => _spotNumber;

}