/*
public class ScreeningManager
{
    private readonly Dictionary<Movie, List<Screening>> _screeningsByMovie = new();
    private readonly Dictionary<Screening, List<Ticket>> _ticketsByScreening = new();

    public ScreeningManager() {}

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

    public List<Screening> FindScreeningsByMovie(Movie movie)
    {
        if(!_screeningsByMovie.TryGetValue(movie, out List<Screening> screenings))
        {
            return new List<Screening>();
        } else {return screenings;}
        
    }
    public List<Ticket> FindTicketsByScreening(Screening screening)
    {
        if (!_ticketsByScreening.TryGetValue(screening, out var tickets))
        {
            return null;
        }
        else {return tickets;}
        
    }
    public List<Seat> GetAvailableSeats(Screening screening)
    {
        List<Seat> allSeats = screening.Room.Layout.GetAllSeats();
        List<Ticket> tickets = FindTicketsByScreening(screening);
        foreach(Ticket ticket in tickets)
        {
            allSeats.Remove(ticket.Seat);
        }
        return allSeats;
        
    }
}