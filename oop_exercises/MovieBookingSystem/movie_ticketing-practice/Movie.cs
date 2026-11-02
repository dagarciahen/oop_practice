public class Movie
{
    public string Name {get;}
    public string Genre {get;}
    public int Duration {get;}
    
    public Movie(string name, string genre, int duration)
    {
        Name = name;
        Genre = genre;
        Duration = duration;
    }
}
