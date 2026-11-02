public class MovieBookingSystem
{
    private ScreeningManager ScreeningManager {get;}
    private List<Movie> Movies {get;}
    private List<Cinema> Cinemas {get;}


    public MovieBookingSystem()
    {
        ScreeningManager = new();
        Movies = new();
        Cinemas = new();
        
    }

    public void AddMovie(Movie movie)
    {
        Movies.Add(movie);
    }
    
    public void AddCinema(Cinema cinema)
    {
        Cinemas.Add(cinema);
    }
    public void BookTicket(Screening screening, Seat seat)
    {
        decimal price = seat.PriceStrategy.Price;
        ScreeningManager.addTicket(new Ticket(screening, price, seat), screening);
    }

    public List<Screening> GetAllScreeningsByMovie(Movie movie)
    {
        return ScreeningManager.GetScreenings(movie);
    }
    
    

}