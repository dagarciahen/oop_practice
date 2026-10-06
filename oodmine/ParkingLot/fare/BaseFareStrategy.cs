using vehicle;
using spot;

namespace fare;

public class BaseFareStrategy : FareStrategy
{
    Dictionary<VehicleSize, decimal> fares = new()
    {
        {VehicleSize.SMALL, 1.0m},
        {VehicleSize.MEDIUM, 2.0m},
        {VehicleSize.LARGE, 3.0m}

    };
    public override decimal calculateFare(Ticket ticket, decimal inputFare)
    {
        decimal fare = inputFare;
        Vehicle vehicle = ticket.Vehicle;
        decimal rate = fares[vehicle.getVehicleSize()];
        fare += rate;
        return fare;


    }


    }