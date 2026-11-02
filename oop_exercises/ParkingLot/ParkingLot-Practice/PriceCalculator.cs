public class PriceCalculator
{
    private readonly List<PriceStrategy> priceStrategies = new();
    public Ticket Ticket {get;}

    public PriceCalculator() {}
    public decimal CalculatePrice(Ticket ticket)
    {
        decimal totalPrice = 0;
        foreach(PriceStrategy strategy in priceStrategies){
            totalPrice += strategy.GetPrice(totalPrice, ticket);
            }
  return totalPrice*GetParkingDuration(ticket);
        
    }
    
    public decimal GetParkingDuration(Ticket ticket)
    {
        DateTime end = ticket.ExitTime ?? DateTime.UtcNow;
        TimeSpan duration = end - ticket.EntryTime;
        return (decimal)duration.TotalMinutes;

    }
}