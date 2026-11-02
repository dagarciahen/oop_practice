public class MotorCycle : Vehicle
{
    public override string LicensePlate {get;}
    public override VehicleSize VehicleSize {get;}

    public MotorCycle(string licensePlate)
    {
        LicensePlate = licensePlate;
        VehicleSize = VehicleSize.SMALL;
    }
}