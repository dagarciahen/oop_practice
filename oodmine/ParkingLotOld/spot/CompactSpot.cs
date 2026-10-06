using vehicle;
namespace spot;

public class CompactSpot : ParkingSpot
{
    private int _spotNumber;
    private Vehicle _vehicle;

    public CompactSpot(int spotNumber)
    {
        _spotNumber = spotNumber;
        _vehicle = null!;
    }
    public override bool isAvailable()
    {
        return _vehicle == null;
    }

    public override void occupy(Vehicle vehicle)
    {
        _vehicle = vehicle;
        
    }
    public override void vaccate()
    {
        _vehicle = null!;
    }

    public override int getSpotNumber() => _spotNumber;

    public override VehicleSize spotSize => VehicleSize.SMALL;
}