public class MovieBookingSystem
{
    public ScreeningManager ScreeningManager {get;}
    public List<Movie> Movies {get;}
    public List<Cinema> Cinemas {get;}

    public MovieBookingSystem()
    {
        ScreeningManager = new();
        Movies = new();
        Cinemas = new();
    }

    public void bookTicket(Screening screening, Seat seat)
    {
        decimal price = seat.PriceStrategy.getPrice();
        ScreeningManager.addTicket(screening, new Ticket(screening, seat, price));
    }
    public List<Seat> getAvailableSeats(Screening screening)
    {
        return ScreeningManager.getAvailableSeats(screening);
    }
    public List<Ticket> getBookedTickets(Screening screening)
    {
        return ScreeningManager.getTicketsByScreening(screening);
    }
    public List<Screening> getScreeningByMovie(Movie movie)
    {
        return ScreeningManager.getScreeningByMovie(movie);
    }


}