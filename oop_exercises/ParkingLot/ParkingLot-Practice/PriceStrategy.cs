public interface IPriceStrategy
{
    decimal GetPrice(decimal intialFare, Ticket ticket);

    
}
public abstract class PriceStrategy : IPriceStrategy
{
    public abstract decimal GetPrice(decimal initialFare, Ticket ticket);


}

public class NormalHoursStrategy : PriceStrategy
{
    private readonly Dictionary<VehicleSize, decimal> ratesbySize = new()
    {
        {VehicleSize.SMALL, 1.0m},
        {VehicleSize.MEDIUM, 2.0m},
        {VehicleSize.LARGE, 3.0M}
    };
    
    public NormalHoursStrategy() {}

    public override decimal GetPrice(decimal inputFare, Ticket ticket)
    {
        decimal fare = inputFare;
       fare += ratesbySize[ticket.Vehicle.VehicleSize]; 
        return fare;
    }
}
public class PeakHoursStrategy : PriceStrategy
{
    private readonly decimal multiplier = 1.5m;
    
    public PeakHoursStrategy() {}

    public override decimal GetPrice(decimal inputFare, Ticket ticket)
    {
        decimal fare = inputFare;
        
        if (IsPeakHours(ticket.EntryTime))
        {
            return multiplier*fare;
        }
        return fare;
    }
    private bool IsPeakHours(DateTime time)
    {
        int hoursTime = time.Hour;
        if ((hoursTime >= 7 && hoursTime <= 13) || (hoursTime >= 17 && hoursTime <= 19))
        {
    
            return true;
            
        }
        return false;
    }
}