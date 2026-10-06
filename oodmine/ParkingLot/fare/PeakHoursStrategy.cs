using vehicle;
using spot;

namespace fare;

public class PeakHoursStrategy : FareStrategy
{
    private readonly decimal multipler = 1.5m;

    public override decimal calculateFare(Ticket ticket, decimal inputFare)
    {
        decimal fare = inputFare;
        if (isPeakHours(ticket.EntryTime))
        {
            fare *= multipler;
        }
        return fare;
    }

    private bool isPeakHours(DateTime time)
    {
        int HoursTime = time.Hour;
        return (HoursTime >= 7 && HoursTime <= 12) || (HoursTime >= 17 && HoursTime <= 19);

    }

}
