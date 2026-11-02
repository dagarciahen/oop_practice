public class ElevatorDispatchController : ElevatorObserver
{
    private readonly ElevatorDispatch _dispatcher;
    private readonly List<ElevatorCar> _elevators;

    public ElevatorDispatchController(ElevatorDispatch dispatcher, List<ElevatorCar> elevators)
    {
        _dispatcher = dispatcher;
        _elevators = elevators;
    }
    public override void Update(int floor, Direction direction)
    {
        Console.WriteLine($"Received Request: Floor: {floor}, Direction: {direction}");
        _dispatcher.DispatchElevator(floor, direction, _elevators); 
        
    }
}