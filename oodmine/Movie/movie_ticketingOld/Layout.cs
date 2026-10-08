public class Layout
{
    private readonly int _rows;
    private readonly int _cols;
    private readonly Dictionary<string, Seat> _seatsByNumber = new();
    private readonly Dictionary<int, Dictionary<int, Seat>> _seatsByPosition = new();
    
    public Layout(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        
    }
    
    public void InitializeLayout()
    {
        for(int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                string seatNumber = i +"-" +j;
                addSeat(i, j, seatNumber, new Seat(seatNumber, null!));
            }
        }

    }
    public void addSeat(int row, int col, string seatNumber, Seat seat)
    {
        _seatsByNumber[seatNumber] = seat;
        if (!_seatsByPosition.ContainsKey(row))
        {
            _seatsByPosition[row] = new Dictionary<int, Seat>();
            
        }
        _seatsByPosition[row][col] = seat;
        
    }
    
    public Seat getSeatByNumber(string seatNumber)
    {
        return _seatsByNumber[seatNumber];
    }
    
    public Seat getSeatByPosition(int row, int col)
    {
        Dictionary<int, Seat> rowSeats = _seatsByPosition[row];
        if (rowSeats is not null)
        {
            return rowSeats[col];
        } else { return null!;
        }

    }
    
    public List<Seat> getAllSeats()
    {
        return new List<Seat>(_seatsByNumber.Values);
    }
}
