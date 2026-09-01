public class Moto implements Vehicle {
    private String lincensePlate;

    public Moto(String lincensePlate) {
        this.lincensePlate = lincensePlate;
    }

    @Override
    public String getLincensePlate() {
        return this.lincensePlate;
    }
    @Override
    public VehicleSize getSize() {
        return this.SMALL;

    }


}