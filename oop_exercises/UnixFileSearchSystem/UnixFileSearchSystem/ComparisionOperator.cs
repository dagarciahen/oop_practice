public interface IComparisionOperator<T>
{
    bool IsMatch(T attributeValue, T expectedValue);

}

public abstract class ComparisionOperator<T> : IComparisionOperator<T>
{
    public abstract bool IsMatch(T attributeValue, T expectedValue);
}