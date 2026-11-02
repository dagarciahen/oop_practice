public class PaymentProcessor
{
    private decimal _currentBalance = 0m;

    public void AddBalance(decimal amount)
    {
        _currentBalance += amount;
    }

    public void ChargeUser(decimal amount)
    {
        _currentBalance -= amount;
    }

    public decimal GiveRest()
    {
        decimal change = _currentBalance;
        _currentBalance = 0;
        return change;
    }
    public decimal GetBalance()
    {
        return _currentBalance;
    }
    
}
