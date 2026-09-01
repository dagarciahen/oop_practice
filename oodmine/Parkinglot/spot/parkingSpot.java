public interface ParkingSpot {
    boolean isAvailable(); //chekcs is spot is free helps ParkingManager decide if spot can be assinged
    void occupy(Vehicle vehicle); //Assings a vehicle to the spot if its avaialbe, setting the vehicle
    void vacate(); //clears the spot by setting the vehicle ot null, mking spot free
    int getSpotNumber();
    VehicleSize getSize(); //Returns the spot fized vehiclesized
}





