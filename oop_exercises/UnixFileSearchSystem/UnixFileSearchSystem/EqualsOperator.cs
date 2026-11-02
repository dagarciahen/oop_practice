using System.Collections.Generic;


public class EqualsOperator<T> : ComparisionOperator<T>
{
    public override bool IsMatch(T attributeValue, T expectedValue)
    {
        return EqualityComparer<T>.Default.Equals(attributeValue, expectedValue);
    
    }
}