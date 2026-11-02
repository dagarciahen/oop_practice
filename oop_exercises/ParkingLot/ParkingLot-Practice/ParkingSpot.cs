public interface IParkingSpot
{
    Vehicle Vehicle {get;set;}
    int SpotNumber {get;}
    bool IsAvailable();
    void vaccate();
    void occupy(Vehicle vehicle);


}

public abstract class ParkingSpot : IParkingSpot
{
    public abstract Vehicle Vehicle {get; set;}
    public abstract int SpotNumber {get;}
    public abstract bool IsAvailable();
    public abstract void occupy(Vehicle vehicle);
    public abstract void vaccate();
}