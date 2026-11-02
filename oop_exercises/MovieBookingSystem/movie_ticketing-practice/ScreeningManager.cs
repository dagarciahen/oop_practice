public class ScreeningManager
{
    private readonly Dictionary<Movie, List<Screening>> _screeningsByMovie = new();
    private readonly Dictionary<Screening, List<Ticket>> _ticketsByScreening = new();
    
    public ScreeningManager() {}

    public void AddScreening(Movie movie, Screening screening)
    {
        _screeningsByMovie.GetValueOrDefault(movie, new List<Screening>());
        _screeningsByMovie[movie].Add(screening);
    }
    
    public void AddTicket(Screening screening, Ticket ticket)
    {
        _ticketsByScreening.GetValueOrDefault(screening, new List<Ticket>());
        _ticketsByScreening[screening].Add(ticket);
    }
    public List<Screening> GetScreenings(Movie movie)
    {
        return _screeningsByMovie[movie] ?? new List<Screening>();
    }
    public List<Ticket> GetTickets(Screening screening) {
        return _ticketsByScreening[screening] ?? new List<Ticket>();
    }
    
    public List<Seat> GetAvailableSeats(Screening screening)
    {
        List<Seat> allSeats = screening.Room.Layout.GetAllSeats();
        List<Ticket> tickets = GetTickets(screening);
        foreach(Ticket ticket in tickets)
        {
            allSeats.Remove(ticket.Seat);
        }
        return allSeats;
    }
}
    