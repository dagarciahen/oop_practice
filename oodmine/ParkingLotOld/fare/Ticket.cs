using vehicle;
using spot;

namespace fare;

public class Ticket
{
    public int TicketId {get;}
    public Vehicle Vehicle {get;}
    public ParkingSpot Spot {get;}
    public DateTime EntryTime {get;}
    public DateTime? ExitTime{get; set;}

    public Ticket(int ticketId, Vehicle vehicle, ParkingSpot spot, DateTime entryTime)
    {
        TicketId = ticketId;
        Vehicle = vehicle;
        Spot = spot;
        EntryTime = entryTime;
        ExitTime = null;
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
