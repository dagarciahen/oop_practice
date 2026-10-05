public class VipPricing : PricingStrategy
{
    private readonly decimal _price;

    public VipPricing(decimal price)
    {
        _price = price;
    }
    
    public override decimal getPrice()
    {
        return _price;
        
    }
}