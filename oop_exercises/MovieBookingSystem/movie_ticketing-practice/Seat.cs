public class Seat
{
    public string SeatNumber {get;}
    public PriceStrategy Price {get;}
    
    public Seat(string seatNumber, PriceStrategy price)
    {
        SeatNumber = seatNumber;
        Price = price;

    }
}