using System.Globalization;
using price;

namespace location;
public class Layout
{
    private int _rows;
    private int _columns;
    private readonly Dictionary<string, Seat> _seatsByNumber = new();
    private readonly Dictionary<int, Dictionary<int, Seat>> _seatsByPosition = new();

    /*
            _seatsByPosition
        │
        ├── row 0 → Dictionary<int, Seat>
        │             ├── column 0 → Seat
        │             ├── column 1 → Seat
        │             └── column 2 → Seat
        │
        ├── row 1 → Dictionary<int, Seat>
        │             ├── column 0 → Seat
        │             ├── column 1 → Seat
        │             └── column 2 → Seat
        │
        └── row 2 → Dictionary<int, Seat>
                    ├── column 0 → Seat
                    └── column 1 → Seat
    
    */

    public Layout(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;

    }
    public void addSeat(string seatNumber, int row, int column, Seat seat)
    {
        if (!_seatsByNumber.ContainsKey(seatNumber))
        {
            _seatsByNumber.Add(seatNumber, seat);
        } else
        {
            Console.WriteLine("SeatNumber not available");
        }
        //row->(column,Seat)
        if (!_seatsByPosition.ContainsKey(row))
        {
            _seatsByPosition.Add(row, new Dictionary<int, Seat>());
        }
        _seatsByPosition[row].Add(column, seat);
        
        
    }

    public Seat getSeatByNumber(string seatNumber)
    {
        if (_seatsByNumber.TryGetValue(seatNumber, out Seat? seat))
        {
            return seat;
        }
        throw new KeyNotFoundException($"Seat {seatNumber} not found");

    }
    public List<Seat> getAllSeats()
    {
        List<Seat> seats = new();
        //return _seatsByNumber.Values.ToList();

        foreach(KeyValuePair<string, Seat> entry in _seatsByNumber)
        {
            seats.Add(entry.Value);

        }
        return seats;
    }

    public Seat getSeatByPosition(int row, int column)
    {
        if (_seatsByPosition.ContainsKey(row) && _seatsByPosition[row].ContainsKey(column))
        {
            return _seatsByPosition[row][column];
        }
        throw new KeyNotFoundException($"Position ({row}, {column}) not found");
    }

    private void initializeLayout()
    {
        for(int i= 0; i < _rows; i++){
            for(int j = 0; j < _columns; j++){
                string seatNumber = i + "-" + j;
                addSeat(seatNumber, i, j, new Seat(seatNumber, null));
                
            }
        }
    }


}