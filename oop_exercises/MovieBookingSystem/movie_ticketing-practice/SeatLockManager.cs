using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

public class SeatLockManager
{
    private readonly ConcurrentDictionary<string, SeatLock> _seatsLocks = new();
    private readonly TimeSpan _lockDuration;
    private readonly object _lock = new();
    
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
    public string GenerateSeatLockId(Screening screening, Seat seat)
    {
        return $"{screening.StartTime:O}-{seat.SeatNumber}";
    }
    public void CleanUpIfExpired(string lockKeyId)
    {
        if (!_seatsLocks.TryGetValue(lockKeyId, out SeatLock? seatLock))
        {
            return;
        }
        if (seatLock.IsExpired())
        {
            _seatsLocks.TryRemove(lockKeyId, out _);
        }
    }
    
    public bool LockSeat(Screening screening, Seat seat, string userId)
    {
        lock (_lock)
        {
            string lockKey = GenerateSeatLockId(screening, seat);
            CleanUpIfExpired(lockKey);
            if (_seatsLocks.ContainsKey(lockKey))
            {
                return false;
            }
            SeatLock seatLock = new SeatLock(userId, DateTime.UtcNow.Add(_lockDuration));       
            _seatsLocks[lockKey] = seatLock;
            return true;
        }
        
    }
    
    public bool UnLockSeat(Screening screening, Seat seat, string userId)
    {
        lock(_lock)
        {
            string lockKey = GenerateSeatLockId(screening, seat);
            CleanUpIfExpired(lockKey);
            if (_seatsLocks.TryGetValue(lockKey, out var seatLock) && seatLock.UserId == userId)
            {
                return _seatsLocks.TryRemove(lockKey, out _);
            }
        
        }
        return false;
    }
}