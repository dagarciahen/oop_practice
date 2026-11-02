public class Ticket
{
    public Screening Screening {get;}
    public decimal Price {get;}
    public Seat Seat {get;}

    public Ticket(Screening screening, decimal price, Seat seat)
    {
        Screening = screening;
        Price = price;
        Seat = seat;
    }
}