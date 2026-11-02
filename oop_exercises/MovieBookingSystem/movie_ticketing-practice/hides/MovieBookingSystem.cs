/*
public class MovieBookingSystem

{
    private readonly ScreeningManager _screeningManager = new();
    public List<Movie> Movies {get;} = new();
    public  List<Cinema> Cinemas {get;}

    public MovieBookingSystem () {}

    public decimal BookTicket(Screening screening, Seat seat)
    {
        Ticket ticket = new Ticket(screening, seat);
        _screeningManager.addTicket(ticket, screening);
        return ticket.GetPrice();
    }

    public List<Ticket> GetAllTicketsByScreening(Screening screening)
    {
        return _screeningManager.FindTicketsByScreening(screening);
        
    }
    public List<Screening> GetAllScreenings(Movie movie)
    {
        return _screeningManager.FindScreeningsByMovie(movie);
    }
}