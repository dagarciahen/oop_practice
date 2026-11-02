public class PaymentProcessor
{
    public decimal CurrentBalance = 0m;

    public void AddBalance(decimal amount)
    {
        CurrentBalance += amount;
    }
    
    public void ChargePrice(decimal amount)
    {
        CurrentBalance -= amount;
    }

    public decimal GiveChange()
    {
        decimal change = CurrentBalance;
        CurrentBalance = 0;
        return change;
    }
}
