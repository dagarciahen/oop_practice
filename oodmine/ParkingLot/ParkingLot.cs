using vehicle;
using spot;
using fare;

public class ParkingLot
{
    private readonly ParkingManager _parkingManager;
    private readonly FareCalculator _fareCalculator;
    private int _nextTicketId = 1;

    public ParkingLot(ParkingManager parkingManager, FareCalculator fareCalculator)
    {
        _parkingManager = parkingManager;
        _fareCalculator = fareCalculator;
    }

    public Ticket enterVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = _parkingManager.parkVehicle(vehicle);
    if  (spot is not null)
        {
            Ticket ticket = new Ticket(_nextTicketId++, vehicle, spot, DateTime.UtcNow);
            return ticket;
            
        } else {}
        return null;

    }
    public void leaveVehicle(Ticket ticket)
    {
        if (ticket is not null && ticket.ExitTime == null)
        {
            ticket.ExitTime = DateTime.UtcNow;
            _parkingManager.unParkVehicle(ticket.Vehicle);
            decimal fare = _fareCalculator.calculateFare(ticket);
        }
        else {}
        
    }
}
