public class LessThanOperator<T> : ComparisionOperator<T> where T: struct, IComparable<T>
{
    public override bool IsMatch(T attributeValue, T expectedValue)
    {
        return attributeValue.CompareTo(expectedValue) < 0;
    }
}
