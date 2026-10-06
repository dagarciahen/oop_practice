using vehicle;
using spot;

namespace fare;

public class PeakHoursStrategy : FareStrategy
{
    private readonly decimal multiplier = 1.5m;

    public override decimal calculateFare(Ticket ticket, decimal inputFare)
    {
        decimal fare = inputFare;
        if (isPeakHours(ticket.EntryTime))
        {
            fare = inputFare*multiplier;
        }
        return fare;
    }

    private bool isPeakHours(DateTime time)
    {
        int hoursTime = time.Hour;
        return (hoursTime >= 7 && hoursTime <= 12) || (hoursTime >= 16 && hoursTime <= 19);
    }
}
