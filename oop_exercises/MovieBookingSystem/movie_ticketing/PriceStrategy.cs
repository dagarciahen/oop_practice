public interface IPriceStrategy
{
    decimal Price {get;}

}
public abstract class PriceStrategy : IPriceStrategy
{
    public abstract decimal Price {get;}
    
}


public class NormalRate : PriceStrategy
{
    decimal Rate {get;}
    public NormalRate(decimal rate) => Rate = rate;
    
    public override decimal Price => Rate;
}

public class VIPRate : PriceStrategy
{
    decimal Rate {get;}
    public VIPRate(decimal rate) => Rate = rate;

    public override decimal Price => Rate;
}
