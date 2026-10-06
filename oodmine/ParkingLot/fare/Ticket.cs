using vehicle;
using spot;

namespace fare;

public class Ticket
{
    public decimal TicketId {get;}
    public Vehicle Vehicle {get;}
    public DateTime EntryTime {get;}
    public DateTime? ExitTime {get;set;}
    public ParkingSpot Spot {get;}

    public Ticket(decimal ticketId, Vehicle vehicle, ParkingSpot spot, DateTime entryTime)
    {
        TicketId = ticketId;
        Vehicle = vehicle;
        Spot = spot;
        EntryTime = entryTime;
    }
    public void setExitTime(DateTime exitTime)
    {
        ExitTime = exitTime;
    }
    public decimal calculateParkDuration()
    {
        DateTime end = ExitTime ?? DateTime.UtcNow;
        return (decimal)(end - EntryTime).TotalMinutes;
    }
}