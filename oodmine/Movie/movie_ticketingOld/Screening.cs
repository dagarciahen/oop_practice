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
    
    public int getDurationinMins()
    {
        TimeSpan duration = EndTime - StartTime;
        return (int)duration.TotalMinutes;

    }

}