public class Cinema
{
    public List<Room> Rooms {get;}
    public string Name {get;}
    public string Location {get;}

    public Cinema(List<Room> rooms, string name, string location)
    {
        Rooms = rooms;
        Name = name;
        Location = location;

    }
    
}
