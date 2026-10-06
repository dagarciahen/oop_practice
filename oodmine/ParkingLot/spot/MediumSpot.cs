using vehicle;

namespace spot;

public class MediumSpot : ParkingSpot
{
    private readonly int _spotNumber;
    private Vehicle _vehicle;

    public MediumSpot(int spotNumber)
    {
        _spotNumber = spotNumber;
        _vehicle = null;
    }
    
    public override int SpotNumber => _spotNumber;
    public override VehicleSize SpotSize => VehicleSize.MEDIUM;
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