public class Transaction
{
    public string TransactionId {get; private set;}
    public Rack Rack {get; private set;}
    public Product Product {get; private set;}
    public decimal TotalAmount {get; private set;}

    public Transaction()
    {
        TransactionId = Guid.NewGuid().ToString();
    }
    
    public void SetRack(Rack rack)
    {
        Rack = rack;
    }
    public void SetProduct(Product product) => Product = product;
    public void SetTotalAmount(decimal amount) => TotalAmount = amount;

    public override string ToString()
    {
        return $"Transaction Id: {TransactionId}, Rack : {Rack}, Product : {Product}, TotalAmount: {TotalAmount}";
    }
    
}