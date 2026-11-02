public class ElevatorDispatch
{
    private readonly DispatchingStrategy _strategy;

    public ElevatorDispatch(DispatchingStrategy strategy) => _strategy = strategy;
    
    public void DispatchElevator(int floor, Direction direction, List<ElevatorCar> elevators)
    {
        ElevatorCar selectedElevatorCar = _strategy.SelectElevator(elevators, floor, direction);
        if (selectedElevatorCar is not null)
        {
            selectedElevatorCar.AddFloorRequest(floor);
        }
    }
    
}