public class ParkingLot
{
    private readonly ParkingManager _parkingManager = new();
    private readonly PriceCalculator _priceCalculator = new();
    private int _nextTicketId = 1;
    
    public ParkingLot() {}
    
    public Ticket EnterVehicle(Vehicle vehicle)
    {
        ParkingSpot spot = _parkingManager.FindAvailableSpot(vehicle);
        if (spot is not null)
        {
            Ticket new_ticket = new Ticket(_nextTicketId++, vehicle, DateTime.UtcNow, spot);

        }
        _parkingManager.ParkVehicle(vehicle);
        return null!;
    }
    
    public void LeaveVehicle(Ticket ticket)
    {
        _parkingManager.UnParkVehicle(ticket.Spot);
        decimal priceToPay = _priceCalculator.CalculatePrice(ticket);
    }


}