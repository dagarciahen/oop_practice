public class ElevatorCar
{
    private ElevatorStatus _status;
    private readonly Queue<int> _targetFloors;

    public ElevatorCar(int startingFloor)
    {
        _status = new ElevatorStatus(startingFloor, Direction.IDLE);

    }
    public ElevatorStatus GetStatus()
    {
        return _status;
    }
    public int GetCurrentFloor()
    {
        return _status.CurrentFloor;
    }
    public Direction GetCurrentDirection()
    {
        return _status.Direction;
    }
    
    public void AddFloorRequest(int floor)
    {
        if (!_targetFloors.Contains(floor))
        {
            _targetFloors.Enqueue(floor);
            UpdateDirection(floor);
        }
    }
    public bool IsIDLE()
    {
        return _targetFloors.Count == 0;
    }

    public void UpdateDirection(int targetFloor)
    {
        if (_status.CurrentFloor < targetFloor)
        {
            _status = new ElevatorStatus(_status.CurrentFloor, Direction.UP);
        } else if (_status.CurrentFloor > targetFloor)
        {
            _status = new ElevatorStatus(_status.CurrentFloor, Direction.DOWN);
        }
    }

    public void MoveOneStep()
    {
        if (_targetFloors.Count == 0) return;

        int nextFloor = _targetFloors.Peek();
        if (_status.CurrentFloor < nextFloor)
        {
            _status = new ElevatorStatus(_status.CurrentFloor +1, Direction.UP);
        }
        else if (_status.CurrentFloor > nextFloor)
        {
            _status = new ElevatorStatus(_status.CurrentFloor -1, Direction.DOWN);
        }
        else
        {
            _targetFloors.Dequeue();
            
        }
        if (_targetFloors.Count == 0)
        {
            _status = new ElevatorStatus(_status.CurrentFloor, Direction.IDLE);
        }
        
    }
    
    public bool IsAtDestination()
    {
        return _targetFloors.Count > 0 && _status.CurrentFloor == _targetFloors.Peek();
    }
    
    public void NextDestination()
    {
        if (IsAtDestination())
        {
            _targetFloors.Dequeue();
        }
    }
    public void MoveUntilNextFloor()
    {
        int nextFloor = _targetFloors.Peek();
    
        while (_status.CurrentFloor != nextFloor)
        {
            MoveOneStep();
        }
}
}

