public class ElevatorStatus
{
    public int CurrentFloor {get; private set;}
    public Direction Direction {get; private set;}
    
    public ElevatorStatus(int currentFloor, Direction direction)
    {
        CurrentFloor = currentFloor;
        Direction = direction;
    }
}