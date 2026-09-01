public class Car implements Vehicle {
    private String lincensePlate;

    public Car(String lincensePlate) {
        this.lincensePlate = lincensePlate;
    }

    @Override
    public String getLincensePlate() {
        return this.lincensePlate;
    }
    @Override
    public VehicleSize getSize() {
        return this.MEDIUM;

    }




}