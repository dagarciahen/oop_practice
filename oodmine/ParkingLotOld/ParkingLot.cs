using fare;
using vehicle;
using spot;

public class ParkingLot
{
    private int _nextTicketId = 1;
    private readonly ParkingManager _parkingManager;
    private readonly FareCalculator _fareCalculator;

    public ParkingLot(ParkingManager parkingManager, FareCalculator fareCalculator)
    {
        _fareCalculator = fareCalculator;
        _parkingManager = parkingManager;

    }
    public Ticket enterVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = _parkingManager.parkVehicle(vehicle);
        if (spot is not null)
        {
            Ticket ticket = new Ticket(_nextTicketId++, vehicle, spot, DateTime.UtcNow);
            return ticket;
        }
        return null;
    }
    public void leaveVehicle(Ticket ticket)
    {
        if (ticket is not null && ticket.ExitTime == null)
        {
            ticket.ExitTime = DateTime.UtcNow;
        _parkingManager.unParkVehicle(ticket.Vehicle);
        decimal fare = _fareCalculator.calculateFare(ticket);
        } else
            {
                Console.WriteLine("ticket invalid or vehicle just leave");
            }
        }
    }