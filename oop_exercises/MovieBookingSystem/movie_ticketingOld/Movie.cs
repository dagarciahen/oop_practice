public class Movie
{
    public string Name {get;}
    public string Genre {get;}
    public int DurationInMins {get;}

    public Movie(string name, string genre, int durationInMins)
    {
        Name = name;
        Genre = genre;
        DurationInMins = durationInMins;
    }

    
}