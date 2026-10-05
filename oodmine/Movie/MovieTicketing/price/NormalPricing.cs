
public class NormalPricing : PricingStrategy
{
    private readonly decimal _price;

    public NormalPricing(decimal price)
    {
        _price = price;
    }
    
    public override decimal getPrice()
    {
        return _price;
        
    }
}