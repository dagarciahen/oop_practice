public class ScreeningManager
{
    private readonly Dictionary<Movie, List<Screening>> _screeningByMovie = new();
    private readonly Dictionary<Screening, List<Ticket>> _ticketsByScreening = new();
    
    public ScreeningManager()
    {
        
    }

    public void addScreening(Movie movie, Screening screening)
    {
        if(!_screeningByMovie.ContainsKey(movie))
        {
            _screeningByMovie[movie] = new List<Screening>();
        }
        _screeningByMovie[movie].Add(screening);
    }
    
    public void addTicket(Screening screening, Ticket ticket)
    {
        if (!_ticketsByScreening.ContainsKey(screening))
        {
            _ticketsByScreening[screening] = new List<Ticket>();
        }
        _ticketsByScreening[screening].Add(ticket);
    }
    
    public List<Screening> getScreeningByMovie(Movie movie)
    {

        return _screeningByMovie.GetValueOrDefault(movie, new List<Screening>());
    }
    public List<Ticket> getTicketsByScreening(Screening screening)
    {
        return _ticketsByScreening.GetValueOrDefault(screening, new List<Ticket>());
    }
    
    public List<Seat> getAvailableSeats(Screening screening)
    {
        List<Ticket> tickets = getTicketsByScreening(screening);
        List<Seat> allSeats = screening.Room.Layout.getAllSeats();
        List<Seat> availableSeats = new List<Seat>(allSeats);
        foreach(Ticket ticket in tickets)
        {
            availableSeats.Remove(ticket.Seat);
        }
        return availableSeats;
    }
    public Ticket BookSeatOptimistically(Screening screening, Seat seat)
    {
        lock (_ticketsByScreening)
        {
            if (IsSeatBooked(screening, seat))
            {
                throw new InvalidOperationException("Seat is already booked");
            }
            
            decimal price = seat.PriceStrategy.getPrice();
            Ticket ticket = new Ticket(screening, seat, price);
            if (!_ticketsByScreening.ContainsKey(screening))
            {
                _ticketsByScreening[screening] = new List<Ticket>();
            }
            _ticketsByScreening[screening].Add(ticket);
            return ticket;
        }
    }
    private bool IsSeatBooked(Screening screening, Seat seat)
    {
        List<Ticket> tickets = getTicketsByScreening(screening);
        foreach( Ticket ticket in tickets)
        {
            if (ticket.Seat == seat)
            {
                return true;
            }
        }
        return false;
    }
    
}