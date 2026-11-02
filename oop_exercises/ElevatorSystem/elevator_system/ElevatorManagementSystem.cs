public class ElevatorManagementSystem
{
    private readonly List<ElevatorCar> _elevators;
    private ElevatorDispatch _dispatchController;
    private DispatchingStrategy _strategy;
    
    public ElevatorManagementSystem(List<ElevatorCar> elevators, DispatchingStrategy strategy)
    {
        _elevators = elevators;
        _strategy = strategy;
    }

    public List<ElevatorStatus> GetAllElevatorStatuses()
    {
        List<ElevatorStatus> statuses = new();
        foreach(ElevatorCar elevator in _elevators)
        {
            statuses.Add(elevator.GetStatus());
        
            
        }
        return statuses;
    }
    
    public void RequestElevator(int currentFloor, Direction direction)
    {
        _dispatchController.DispatchElevator(currentFloor, direction, _elevators);
        
    }
    
    public void SelectFloor(ElevatorCar car, int destinationFloor)
    {
        car.AddFloorRequest(destinationFloor);
        
    }
    } 
    