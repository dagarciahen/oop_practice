namespace price;

public class PremiumPricing : PricingStrategy
{
    private readonly decimal _price;

    public PremiumPricing(decimal price)
    {
        _price = price;
    }
    public override decimal getPrice()
    {
        return _price;
    }
}