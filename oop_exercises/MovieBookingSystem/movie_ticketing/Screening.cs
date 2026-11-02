public class Screening
{
    public DateTime StartTime {get;}
    public DateTime EndTime {get;}
    public Movie Movie {get;}
    public Room Room {get;}


    public Screening(DateTime startTime, DateTime endTime, Movie movie, Room room)
    {
        StartTime = startTime;
        EndTime = endTime;
        Movie = movie;
        Room = room;
    }

    public TimeSpan GetDuration()
    {
        return EndTime - StartTime;
    }
}