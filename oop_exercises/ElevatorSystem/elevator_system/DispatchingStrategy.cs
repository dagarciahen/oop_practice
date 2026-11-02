public interface IDispatchingStrategy
{
    ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction);
}

public abstract class DispatchingStrategy : IDispatchingStrategy
{
    public abstract ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction);
}

public class FirstComeFirstServeStrategy : DispatchingStrategy
{
    public override ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction)
    {
        foreach(ElevatorCar elevator in elevators)
        {
            if (elevator.IsIDLE() || elevator.GetCurrentDirection() == direction)
            {
                return elevator;
                
            }
        }
        Random rnd = new Random();
        int randomSelector = rnd.Next(0, elevators.Count);
        return elevators[randomSelector];
    }
}

//this strategyu prioritizes the elevator that is closest to the request floor
// it calculates the absolute distance between the current floor of eahc elevator and the request floor
//and selects teh elevator that can reach teh rqueested floor the quickest
//this strategy also takes into account whether the elevator is idle or moving tin the correct direction

//--> elevator that are idle or moving in the correct direciton are prioritized
//--> if multiple elevators are equidistant to req floor the first one encountered is selected
public class ShortestSeekTimeFirstStrategy : DispatchingStrategy
{
    public override ElevatorCar SelectElevator(List<ElevatorCar> elevators, int floor, Direction direction)
    {
        ElevatorCar bestElevator = null!;
        int shortestDistance = int.MaxValue;
        foreach(ElevatorCar elevator in elevators)
        {
            int distance = Math.Abs(elevator.GetCurrentFloor() - floor);
            if ((elevator.IsIDLE() || elevator.GetCurrentDirection() == direction) && distance < shortestDistance)
            {
                bestElevator = elevator;
                shortestDistance = distance;
            }
        }
        return bestElevator;
    }
}