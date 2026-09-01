using System;
using System.Text;

namespace vehicle;

public class Car : Vehicle
{
    private string _licensePlate;
    public Car(string licensePlate)
    {
        _licensePlate = licensePlate;
    }

    public override string getLicensePlate()
    {
        return _licensePlate;
    }

    public override string getVehicleSize()
    {
        return VehicleSize.MEDIUM;
    }

}

