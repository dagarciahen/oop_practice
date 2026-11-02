public class Car : Vehicle
{
    public override string LicensePlate {get;}
    public override VehicleSize VehicleSize{get;}
    public Car (string licensePlate)
    {
        LicensePlate = licensePlate;
        VehicleSize = VehicleSize.MEDIUM;
        
    }
}