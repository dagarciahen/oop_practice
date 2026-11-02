public class MediumSpot : ParkingSpot
{
    public override int SpotNumber {get;}
    public override Vehicle Vehicle {get;set;}


    public MediumSpot(int spotNumber) => SpotNumber = spotNumber;

    public override bool IsAvailable()
    {
        return Vehicle == null;
    }
    public override void vaccate()
    {
        Vehicle = null;
        
    }
    public override void occupy(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
}