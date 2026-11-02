public class Ticket
{
    public int TicketId {get; set;}
    public ParkingSpot Spot {get;}
    public DateTime EntryTime {get;}
    public DateTime? ExitTime {get; set;}
    public Vehicle Vehicle {get;set;}

    public Ticket(int ticketId, Vehicle vehicle, DateTime entryTime, ParkingSpot spot)
    {
        TicketId = ticketId;
        Vehicle = vehicle;
        Spot = spot;
        EntryTime = entryTime;
    }
    
    
}