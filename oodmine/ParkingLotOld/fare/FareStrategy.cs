namespace fare;

public interface IFareStrategy
{
    decimal calculateFare(Ticket ticket, decimal inputFare);

}
public abstract class FareStrategy : IFareStrategy
{
public abstract decimal calculateFare(Ticket ticket, decimal inputFare);
}