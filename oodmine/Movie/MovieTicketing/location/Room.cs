namespace location;
public class Room
{
   private readonly Layout _layout;
   private readonly int _roomId;

    
    public Room(Layout layout, int roomId)
    {
        _layout = layout;
        _roomId = roomId;
    }

    public Layout layout => _layout;
    public int roomId => _roomId;
}


  