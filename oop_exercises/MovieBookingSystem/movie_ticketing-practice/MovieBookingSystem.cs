public class MovieBookingSystem
{
    private readonly ScreeningManager _screeningManager = new();
    private readonly List<Movie> _movies = new();
    private readonly List<Room> _rooms = new();
    private readonly object _lock = new();

    public MovieBookingSystem(){}

    public void BookTicket(Screening screening, Seat seat)
    {
        decimal price =  seat.Price.Price;
        Ticket ticket = new Ticket(screening, seat, price);
        _screeningManager.AddTicket(screening, ticket);
    }
    
    //Optimisc look first verify if the seat is available avoiding lock seats during booking
    //if seat is not available return error to the user and he tries again
    //this is good for low contention scenarios where not so many bookings are expected 
    public void OptimisticBook(Screening screening, Seat seat)
    {
        if(!IsSeatAvailable(screening, seat))
        {
            Console.WriteLine("Seat is taken");
            return;
        }
        decimal price = seat.Price.Price;
        Ticket ticket = new Ticket(screening, seat, price);

        _screeningManager.AddTicket(screening, ticket);

    }
    private bool IsSeatAvailable(Screening screening, Seat seat)
    {
        List<Seat> availableSeats = _screeningManager.GetAvailableSeats(screening);
        if (availableSeats.Contains(seat))
        {
            return false;
        }
        return true;

        
    }
    
    public List<Screening> GetScreeningsByMovie(Movie movie)
    {
        return _screeningManager.GetScreenings(movie);
    }
    
    public List<Seat> GetAvailableSeats(Screening screening)
    {
       return _screeningManager.GetAvailableSeats(screening);
    }
    
}

