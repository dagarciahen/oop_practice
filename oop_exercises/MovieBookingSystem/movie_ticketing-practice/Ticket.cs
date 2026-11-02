public class Ticket
{
    public Screening Screening {get;}
    public Seat Seat{get;}
    public decimal Price {get;}

    public Ticket(Screening screening, Seat seat, decimal price)
    {
        Screening = screening;
        Seat = seat;
        Price = price;
    }
}