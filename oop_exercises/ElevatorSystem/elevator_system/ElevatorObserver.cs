public interface IElevatorObserver
{
    void Update(int floor, Direction direction);
}

public abstract class ElevatorObserver : IElevatorObserver
{
    public abstract void Update(int floor, Direction direction);
}