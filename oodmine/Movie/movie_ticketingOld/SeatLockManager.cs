using System.Collections.Concurrent;

public class SeatLockManager
{
    private readonly ConcurrentDictionary<string, SeatLock> _lockedSeats = new();
    private readonly TimeSpan _lockDuration;

    public SeatLockManager(TimeSpan lockDuration)
    {
        _lockDuration = lockDuration;
} 
    
    private sealed class SeatLock
    {
        public string UserId {get;}
        public DateTime ExpirationDate {get;}
        public SeatLock(string userId, DateTime expirationDate)
        {
            UserId = userId;
            ExpirationDate = expirationDate;
            
        }
        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpirationDate;
        }
    }        
    private string GenerateLockId(Screening screening, Seat seat)
    {
        return $"{screening.StartTime:O}-{screening.Room.Name}-{seat.SeatNumber}";
    }
    private void CleanUpIfExpired(string lockKey)
    {
        if (_lockedSeats.TryGetValue(lockKey, out SeatLock? seatLock) && (seatLock.IsExpired()))
        {
            _lockedSeats.TryRemove(lockKey, out _);
            
        }
    }
    public bool LockSeat(Screening screening, Seat seat, string UserId)
    {
        lock(_lockedSeats)
        {
            string lockKey = GenerateLockId(screening, seat);
            CleanUpIfExpired(lockKey);
            if (_lockedSeats.ContainsKey(lockKey))
            {
                return false;
            }
            var seatLock = new SeatLock(UserId, DateTime.UtcNow.Add(_lockDuration));
            _lockedSeats[lockKey] = seatLock;
            return true;
        }
    }

    public bool IsLocked(Screening screening, Seat seat)
    {
        string lockKey = GenerateLockId(screening, seat);
        CleanUpIfExpired(lockKey);
        return _lockedSeats.ContainsKey(lockKey);
    }

    public bool UnLockSeat(Screening screening, Seat seat, string userId)
    {
        lock(_lockedSeats)
        {
            string lockKey = GenerateLockId(screening, seat);
            CleanUpIfExpired(lockKey);
            if (_lockedSeats.TryGetValue(lockKey, out SeatLock? seatLock) && seatLock.UserId == userId)
            {
                return _lockedSeats.TryRemove(lockKey, out _);
            }
            return false;
        }
        
    }
}



        