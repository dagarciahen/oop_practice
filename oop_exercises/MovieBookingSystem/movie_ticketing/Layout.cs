public class Layout
{
    private readonly int _rows;
    private readonly int _cols;

    private readonly Dictionary<string, Seat> _seatsByNumber = new();
    private readonly Dictionary<int, Dictionary<int, Seat>> _seatsByPosition = new();

    public Layout(int rows, int  cols)
    {
        _rows = rows;
        _cols = cols;
    }
    
    public void InitializeAsync(int rows, int cols)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j= 0; j < _cols; j++)

            {
                string seatNumber = i + "-"+j;
                addSeat(i, j, seatNumber, new Seat(seatNumber, null!));
                
            }
        }
        
    }
    public void addSeat(int row, int col, string seatNumber, Seat seat)
    {
        _seatsByNumber[seatNumber] = seat;
        if (!_seatsByPosition.TryGetValue(row, out var seatsInRow))
        {
            seatsInRow = new Dictionary<int, Seat>();
        }
            seatsInRow[col] = seat;
    }
    public List<Seat> GetSeats()
    {
        return new List<Seat>(_seatsByNumber.Values);
    }
    
}