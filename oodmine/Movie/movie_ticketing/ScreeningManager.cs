public class ScreeningManager
{
    private readonly Dictionary<Movie, List<Screening>> _screeningsByMovie = new();
    private readonly Dictionary<Screening, List<Ticket>> _ticketsByScreening = new();
    
    public ScreeningManager()
    {
        
    }
    public void addScreening(Movie movie, Screening screening)
    {
        _screeningsByMovie.GetValueOrDefault(movie, new List<Screening>());
        _screeningsByMovie[movie].Add(screening);
    }

    public void addTicket(Ticket ticket, Screening screening)
    {
        _ticketsByScreening.GetValueOrDefault(screening, new List<Ticket>());
        _ticketsByScreening[screening].Add(ticket);
    }
    
    public List<Seat> GetAllSeats(Screening screening)
    {
        return screening.Room.Layout.GetSeats();
    }

    public List<Seat> GetAvailableSeats(Screening screening)
    {
        List<Ticket> tickets = _ticketsByScreening[screening];
        List<Seat> availableSeats = GetAllSeats(screening);
        foreach(Ticket ticket in tickets)
        {
            availableSeats.Remove(ticket.Seat);
        }
        return availableSeats;
        
    }
    public List<Screening> GetScreenings(Movie movie)
    {
        return _screeningsByMovie.GetValueOrDefault(movie, new List<Screening>());
    }
    
}
