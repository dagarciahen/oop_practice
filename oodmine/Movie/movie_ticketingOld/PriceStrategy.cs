public interface IPriceStrategy
{
    decimal getPrice();

}

public abstract class PriceStrategy : IPriceStrategy
{
    public abstract decimal getPrice();
}

public class NormalRate : PriceStrategy
{
    public decimal Rate {get;}
    
    public NormalRate(decimal rate)
    {
        Rate = rate;
    }
    
    public override decimal getPrice()
    {
        return Rate;
    }

}

public class VIPRate : PriceStrategy
{
      public decimal Rate {get;}
    
    public VIPRate(decimal rate)
    {
        Rate = rate;
    }
    
    public override decimal getPrice()
    {
        return Rate;
    }

}
public class PremiumRate : PriceStrategy
{
      public decimal Rate {get;}
    
    public PremiumRate(decimal rate)
    {
        Rate = rate;
    }
    
    public override decimal getPrice()
    {
        return Rate;
    }
    
}