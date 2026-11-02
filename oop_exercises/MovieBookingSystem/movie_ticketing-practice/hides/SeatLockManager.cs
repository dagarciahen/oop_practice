/*
using System.Collections.Concurrent;



public class SeatLockManager
{
    private readonly ConcurrentDictionary<string, SeatLock> _seatsLock = new();
    public TimeSpan LockDuration {get;}
    
    public SeatLockManager(TimeSpan lockDuration)
    {
        LockDuration = lockDuration;
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
            return $"{screening.StartTime:O}-{screening.EndTime}";
        }
        public bool IsLocked(Screening screening, Seat seat)
        {
            string lockKey = GenerateSeatLockId(screening, seat);
            CleanUpIfExpired(lockKey);
            return _seatsLock.ContainsKey(lockKey);
        }
        private void CleanUpIfExpired(string lockKey)
    {
        if (!_seatsLock.TryGetValue(lockKey, out SeatLock? seatLock))
        {
            return;
        }
        if (seatLock.IsExpired())
        {
            _seatsLock.TryRemove(lockKey, out _);
        }
    }

    public bool LockSeat(Screening screening, Seat seat, string userId)
    {
        string lockKey = GenerateSeatLockId(screening, seat);
        CleanUpIfExpired(lockKey);
        if( IsLocked(screening, seat))
        {
            return false;
        }
        SeatLock seatLock = new SeatLock(userId, DateTime.UtcNow.Add(LockDuration));
        _seatsLock[lockKey] = seatLock;
        return true;
}
public bool UnLockSeat(Screening screening, Seat seat, string userId)
    {
        string lockKey = GenerateSeatLockId(screening,seat);
        CleanUpIfExpired(lockKey);
        if (_seatsLock.TryGetValue(lockKey, out SeatLock? seatLock) && seatLock.UserId == userId)
        {
            return _seatsLock.TryRemove(lockKey, out _);
        }
        return true;
            
        }
}