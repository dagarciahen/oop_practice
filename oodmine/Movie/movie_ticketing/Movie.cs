public class Movie
{
    public String Name {get;}
    public int DurationInMins {get;}
    public string Genre {get;}

    public Movie(string name, string genre, int durationInMins)
    {
        Name = name;
        Genre = genre;
        DurationInMins = durationInMins;
    }
}