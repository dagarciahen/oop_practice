using vehicle;

namespace spot;

public class LargeSpot : ParkingSpot
{
    private readonly int _spotNumber;
    private Vehicle _vehicle;

    public LargeSpot(int spotNumber)
    {
        _spotNumber = spotNumber;
        _vehicle = null;
    }
    
    public override int SpotNumber => _spotNumber;
    public override VehicleSize SpotSize => VehicleSize.LARGE;
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
}



