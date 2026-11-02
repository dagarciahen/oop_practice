public class Rack
{
    public string RackId {get;}
    public Product Product {get;}
    public int Count {get; set;}

    public Rack(string rackId, Product product, int count)
    {
        RackId = rackId;
        Product = product;
        Count = count;
    }
}