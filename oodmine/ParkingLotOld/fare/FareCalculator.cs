using vehicle;
using spot;

namespace fare;

public class FareCalculator
{
    private readonly List<FareStrategy> _fareStrategies;

    public FareCalculator(List<FareStrategy> fareStrategies)
    {
        _fareStrategies = fareStrategies;
    }
    public decimal calculateFare(Ticket ticket)
    {
        decimal fare = 0m;
        foreach(FareStrategy strategy in _fareStrategies)
        {
            fare = strategy.calculateFare(ticket, fare);
        }
        return fare;
    }

}