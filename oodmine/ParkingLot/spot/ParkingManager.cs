using vehicle;
namespace spot;

public interface IParkingManger
{
    ParkingSpot findAvailableSpot(Vehicle vehicle);
    ParkingSpot parkVehicle(Vehicle vehicle);
    void unParkVehicle(ParkingSpot spot);
    Vehicle findVehicleBySpot(ParkingSpot spot);
    ParkingSpot findSpotByVehicle(Vehicle vehicle);
}

public class ParkingManager
{
    Dictionary<VehicleSize, List<ParkingSpot>> _availableSpots;
    Dictionary<Vehicle, ParkingSpot> _vehicleToSpotMap;
    Dictionary<ParkingSpot, Vehicle> _spotToVehicleMap;
    
    public ParkingManager(Dictionary<VehicleSize, List<ParkingSpot>> availableSpots)
    {
        _availableSpots = availableSpots;
    }

    public ParkingSpot findAvailableSpot(Vehicle vehicle)
    {
        VehicleSize vehSize = vehicle.getVehicleSize();
        foreach (VehicleSize size in Enum.GetValues<VehicleSize>())
        {
            if (vehSize <= size)
            {
                foreach(ParkingSpot spot in _availableSpots[size])
                {
                    if (spot.isAvailable())
                    {
                        _availableSpots[size].Remove(spot);
                        return spot;
                    }
                }
            }
            
        }
        return null!;

    }
    public ParkingSpot parkVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = findAvailableSpot(vehicle);
        if (spot is not null)
        {
            spot.occupy(vehicle);
            _spotToVehicleMap[spot] = vehicle;
            _vehicleToSpotMap[vehicle] = spot;
            return spot;
        }
        return null;
    }
    public void unParkVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = _vehicleToSpotMap[vehicle];
        if (spot is not null)
        {
            spot.vaccate();
            _availableSpots[spot.SpotSize].Add(spot);
            _spotToVehicleMap.Remove(spot);
            _vehicleToSpotMap.Remove(vehicle);
        }
        
    }
    
    public ParkingSpot findVehicleBySpot(Vehicle vehicle)
    {
        return _vehicleToSpotMap[vehicle];
    }
    public Vehicle findSpotByVehicle(ParkingSpot spot)
    {
        return _spotToVehicleMap[spot];
    }

    
}