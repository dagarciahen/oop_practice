public class SimplePredicate<T> : Predicate
{
    public FileAttributeType AttributeName {get;}
    public ComparisionOperator<T> Operator{get;}
    public T ExpectedValue {get;}

    public SimplePredicate(FileAttributeType attributeName, ComparisionOperator<T> comparisionOperator, T expectedValue)
    {
        AttributeName = attributeName;
        Operator = comparisionOperator;
        ExpectedValue = expectedValue;

        
    }

    public override bool IsMatch(File inputFile)
    {
        object? actualValue = inputFile.Extract(AttributeName);
        if (actualValue is T typedValue)
        {
            return Operator.IsMatch(typedValue, ExpectedValue);
        }
        return false;

    }

    
}