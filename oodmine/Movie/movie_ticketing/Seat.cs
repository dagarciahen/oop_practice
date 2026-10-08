public class Seat
{
    public string SeatNumber {get;}
    public PriceStrategy PriceStrategy {get;}

    public Seat(string seatNumber, PriceStrategy priceStrategy)
    {
        SeatNumber = seatNumber;
        PriceStrategy = priceStrategy;
    }
}