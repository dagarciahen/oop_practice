public class OversizedSpot implements ParkingSpot {
    private int spotNumber;
    private Vehicle vehicle;
    
    public OversizedSpot(int spotNumber, Vehicle vehicle) {
        this.spotNumber = spotNumber;
        this.Vehicle = vehicle
    }
    @Override
    public boolean isAvailable() {
        return vehicle == null;
    }
    @Override
    public void occupy() {
        if (isAvailable()) {
            this.vehicle = vehicle;
        } else {
            System.out.println("Spot already occupied");
        }
    }
    @Override
    public int getSpotNumber() {
        return spotNumber;
    }
    @Override
    public VehicleSize getSize() {
        return VehicleSize.LARGE,
    }