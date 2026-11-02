public class ParkingManager
{
    private readonly Dictionary<VehicleSize, Dictionary<int, ParkingSpot>> _availableSpots = new();
    private readonly Dictionary<Vehicle, ParkingSpot> _vehicleToSpotMap = new();
    private readonly Dictionary<ParkingSpot, Vehicle> _spotToVehicle = new();
    
    public ParkingManager () {}
    
    public ParkingSpot FindAvailableSpot(Vehicle vehicle)
    {
        VehicleSize vehSize = vehicle.VehicleSize;
        foreach(VehicleSize size in Enum.GetValues<VehicleSize>())
        {
            if (size >= vehSize)
            {
                foreach(ParkingSpot spot in _availableSpots[size].Values)
                {
                    if (spot.IsAvailable())
                    {
                        return spot;
                    }
                    
                }
            }
            
        }
        return null;

    }
    public ParkingSpot ParkVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = FindAvailableSpot(vehicle);
        if (spot is not null)
        {
            _availableSpots[spot.Vehicle.VehicleSize].Remove(spot.SpotNumber);
            _vehicleToSpotMap[vehicle] = spot;
            _spotToVehicle[spot] = vehicle;
            return spot;
        }
        return null;
    }
    public void UnParkVehicle(ParkingSpot spot)
    {
        if (!spot.IsAvailable())
        {
            _availableSpots[spot.Vehicle.VehicleSize].Add(spot.SpotNumber, spot);
            _vehicleToSpotMap.Remove(spot.Vehicle);
            _spotToVehicle.Remove(spot);
            spot.vaccate();

        }
        return; 
    }
    public Vehicle FindVehicleBySpot(ParkingSpot spot)
    {
        return _spotToVehicle.GetValueOrDefault(spot, null!);
        
    }
    public ParkingSpot FindSpotByVehicle(Vehicle vehicle)
    {
        return _vehicleToSpotMap.GetValueOrDefault(vehicle, null!);
    }
}