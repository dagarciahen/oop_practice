
public interface IPricingStrategy
{
    decimal getPrice();
    
}

public abstract class PricingStrategy : IPricingStrategy
{
    public PricingStrategy(){}
    
    public abstract decimal getPrice();
}
