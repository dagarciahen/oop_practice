public class CompactSpot implements ParkingSpot {
    private int spotNumber;
    private Vehicle vehicle;

    public CompactSpot(int spotNumber) {
        this.spotNumber = spotNumber;
        this.vehicle = null; //no vehicle initially occupyng
    }
    @Override
    public int getSpotNumber() {
        return spotNumber;
    }
    @Override
    public boolean isAvailable() {
        return vehicle = null;
    }
    @Override
    public void occupy(Vehicle vehicle) {
        if (isAvailable()) {
            this.vehicle = vehicle;
        } else {
            System.out.println("Spot is already occupied");
        }
    }
    @Override
    public void vacate() {
        this.vehicle = null; //make spot avaialbe
    }
    @Override
    public VehicleSize getSize() {
        return VehicleSize.SMALL;
    }
    }