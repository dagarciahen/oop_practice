public class Rack
{
    public string RackCode {get;}
    public Product Product {get;}
    public int Count{get; set;}

    public Rack(string rackCode, Product product)
    {
        RackCode = rackCode;
        Product = product;
    }

    
}