using System.Text.RegularExpressions;


public class RegexMatchOperator<T> : ComparisionOperator<T>
{
    public override bool IsMatch(T attributeValue, T expectedValue)
    {
        string attribute = attributeValue?.ToString() ?? "";
        string expected = expectedValue?.ToString() ?? "";
        return Regex.IsMatch(attribute, $"\\A(?:{expected}\\z)"); // \A start string \z end string
    }
}

