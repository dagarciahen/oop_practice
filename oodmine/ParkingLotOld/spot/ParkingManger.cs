using vehicle;

namespace spot;

public class ParkingManager
{
    private readonly Dictionary<VehicleSize, List<ParkingSpot>> _availableSpots;
    private readonly Dictionary<Vehicle, ParkingSpot> _vehicleToSpotMap;
    private readonly Dictionary<ParkingSpot, Vehicle> _spotToVehicleMap;

public ParkingManager(Dictionary<VehicleSize, List<ParkingSpot>> availableSpots)
    {
        _availableSpots = availableSpots;
        _vehicleToSpotMap = new();
        _spotToVehicleMap = new();
    }
    public ParkingSpot findAvailableSpot(Vehicle vehicle)
    {
        VehicleSize vehSize = vehicle.getVehicleSize();
        foreach(VehicleSize size in Enum.GetValues<VehicleSize>())
        {
            if (vehSize <= size)
            {
                foreach(ParkingSpot spot in _availableSpots[size])
                {
                    if (spot.isAvailable())
                    {
                        return spot;
                    }
                }

            }
        }
        return null;
        
    }
    public ParkingSpot parkVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = findAvailableSpot(vehicle);
        if (spot is not null)
        {
            spot.occupy(vehicle);
            _availableSpots[spot.spotSize].Remove(spot);
            _vehicleToSpotMap[vehicle] = spot;
            _spotToVehicleMap[spot] = vehicle;
            return spot;
        }
        return null;

    }
    public void unParkVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = _vehicleToSpotMap[vehicle];
        spot.vaccate();
        _availableSpots[spot.spotSize].Add(spot);
        _vehicleToSpotMap.Remove(vehicle);
        _spotToVehicleMap.Remove(spot);

    }

    public ParkingSpot findVehiclebySpot(Vehicle vehicle)
    {
        return _vehicleToSpotMap[vehicle];        
    }
    public Vehicle findSpotByVehicle(ParkingSpot spot)
    {
        return _spotToVehicleMap[spot];
    }
}

    

    
