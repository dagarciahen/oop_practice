using System.Collections.Concurrent;


public class SeatLockManager
{
    private readonly ConcurrentDictionary<string, SeatLock> _seatsLocks = new();
    public TimeSpan LockedDuration {get;}
    private readonly object _lock = new();

    public SeatLockManager(TimeSpan lockedDuration)
    {
        LockedDuration = lockedDuration;
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

    
    private string GenerateLockKeyId(Screening screening, Seat seat)
    {
        return $"{screening.StartTime:O}-{seat.SeatNumber}";
    }
    public bool IsLocked(Screening screening, Seat seat)
    {
        string lockKey = GenerateLockKeyId(screening, seat);
        CleanUpIfExpired(lockKey);
        return _seatsLocks.ContainsKey(lockKey);
    }

    private void CleanUpIfExpired(string lockKey)
    {
        if(!_seatsLocks.TryGetValue(lockKey, out SeatLock? seatLock))
        {
            return;
        }
        if (seatLock.IsExpired())
        {
            _seatsLocks.TryRemove(lockKey, out _);
        }
            
        }

    public bool LockSeat(Screening screening, Seat seat, string userId)
    {
        lock (_lock)
        {
            string lockKey = GenerateLockKeyId(screening, seat);
            CleanUpIfExpired(lockKey);
            if (_seatsLocks.ContainsKey(lockKey))
                {
                    return false;
                }
            SeatLock seatLock = new SeatLock(userId, DateTime.UtcNow.Add(LockedDuration));
            _seatsLocks[lockKey] = seatLock;
            return true;
        }
    }
    public bool UnLockSeat(Screening screening, Seat seat, string userId)
    {
        lock (_lock)
        {
        string lockKey = GenerateLockKeyId(screening, seat);
        CleanUpIfExpired(lockKey);
        if (_seatsLocks.TryGetValue(lockKey, out SeatLock? seatLock) && seatLock.UserId == userId)
        {
            return _seatsLocks.TryRemove(lockKey, out _);
        }
        return false;
    }
}
}

    