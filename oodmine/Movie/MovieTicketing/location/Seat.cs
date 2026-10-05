using System.Reflection.Metadata.Ecma335;
using price;

namespace location;
public class Seat
{
    private readonly string _seatNumber;
    private readonly PricingStrategy _pricingStrategy;

    public Seat(string seatNumber, PricingStrategy pricingStrategy)
    {
        _seatNumber = seatNumber;
        _pricingStrategy = pricingStrategy;
    }

    public string seatNumber => _seatNumber;
    public PricingStrategy pricingStrategy => _pricingStrategy;
   
}