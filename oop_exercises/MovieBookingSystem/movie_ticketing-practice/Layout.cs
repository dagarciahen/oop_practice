public class Layout
{
    private readonly int _rows;
    private readonly int _cols;

    private readonly Dictionary<string, Seat> _seatByNumber = new();
    private readonly Dictionary<int, Dictionary<int, Seat>> _seatsByPosition = new();

    public Layout(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
    }
    
    public void InitializeLayout(int rows, int cols)
    {
        for (int i=0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                string seatNumber = i + "-"+ j;
                AddSeat(i, j, seatNumber, new Seat(seatNumber, null!));
            }
        }
    }
    public void AddSeat(int row, int col, string seatNumber, Seat seat)
    {
        _seatByNumber[seatNumber]= seat;
        _seatsByPosition.GetValueOrDefault(row, new Dictionary<int, Seat>());
        _seatsByPosition[row][col] = seat;
    }

    public List<Seat> GetAllSeats()
    {
        return new List<Seat>(_seatByNumber.Values);
    }
}