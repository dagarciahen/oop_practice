using System.Collections.Generic;


//greather than comparision for numeric values I need to use where T : INumber<T>(System.Numerics) or IComparable<T>c
public class GreaterThanOperator<T> : ComparisionOperator<T> where T: struct, IComparable<T>
{
    public override bool IsMatch(T attributeValue, T expectedValue)
    {
        return attributeValue.CompareTo(expectedValue) > 0;
    
    }
}