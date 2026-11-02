public class Product
{
    public string ProductId {get;}
    public decimal UnitPrice {get;}

    public Product(string productId, decimal unitPrice)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        
    }
}