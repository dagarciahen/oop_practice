public class IPriceStrategy
{
    decimal Price {get;}

}

public abstract class PriceStrategy : IPriceStrategy
{
    public abstract decimal Price {get;}
}

public abstract class NormalStrategy : PriceStrategy
{
    public decimal Rate {get;}
    
    public NormalStrategy(decimal rate) => Rate = rate;
    
    public override decimal Price => Rate;

}
public abstract class VIPStrategy : PriceStrategy
{
    public decimal Rate {get;}
    
    public VIPStrategy(decimal rate) => Rate = rate;
    
    public override decimal Price => Rate;

}
