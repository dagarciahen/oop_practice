
/*
public class Layout
{
    private readonly Dictionary<string, Seat> _seatsByNumber = new();
    private readonly Dictionary<int, Dictionary<int, Seat>> _seatsByPosition = new();

    private int _rows;
    private int _cols;

    public Layout(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
    }
    
    public void InitializeLayout()
    {
        for(int i = 0; i < _rows; i++)
        {
            for(int j= 0; j < _cols; j++)
            {
                string seatNumber = i + "-" +j;
                addSeat(i, j, seatNumber, new Seat(seatNumber, null!));
            }
        }
    }
    
    public void addSeat(int row, int col, string seatNumber, Seat seat)
    {
        _seatsByNumber[seatNumber] = seat;
        _seatsByPosition.GetValueOrDefault(row, new Dictionary<int, Seat>());
        _seatsByPosition[row][col] = seat;
        
    }

    public List<Seat> GetAllSeats()
    {
        return new List<Seat>(_seatsByNumber.Values);
    }
}