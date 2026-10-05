namespace location;

public class Cinema
{
    private List<Room> _rooms;
    private string _name;
    private readonly string _location;

    public Cinema(List<Room> rooms, string name, string location)
    {
        _rooms = rooms;
        _name = name;
        _location = location;

    }

    public List<Room> rooms => _rooms;
    public string name => _name;
    public string location => _location;

    public void addRoom(Room room)
    {
        _rooms.Add(room);
    }

}