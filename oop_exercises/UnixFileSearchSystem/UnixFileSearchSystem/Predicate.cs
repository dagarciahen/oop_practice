public interface IPredicate
{
    bool IsMatch(File inputFile);
}

public abstract class Predicate<T> : IPredicate
{
    public abstract bool IsMatch(File inputFile);
}

