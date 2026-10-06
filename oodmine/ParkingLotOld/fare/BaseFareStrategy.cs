using vehicle;
using spot;
namespace fare;

public class BaseFareStrategy : FareStrategy
{
    private readonly Dictionary<VehicleSize, decimal> fares = new()
    {
        {VehicleSize.SMALL, 1.0m},
        {VehicleSize.MEDIUM, 2.0m},
        {VehicleSize.LARGE, 3.0m}
    };
    public override decimal calculateFare(Ticket ticket, decimal inputFare)
    {
        decimal fare = inputFare;
        VehicleSize size = ticket.Vehicle.getVehicleSize();
        decimal rate = fares[size];
        fare += rate*ticket.calculateParkDuration();
        return fare;
    }
    
}