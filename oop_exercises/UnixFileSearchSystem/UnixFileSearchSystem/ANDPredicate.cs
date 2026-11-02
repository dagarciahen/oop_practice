public class AndPredicate : ICompositePredicate
{
    private readonly List<IPredicate> _operands;
    
    public AndPredicate(List<IPredicate> operands)
    {
        _operands = operands;
    }
    
    public bool IsMatch(File inputFile)
    {
        return _operands.All(predicate => predicate.IsMatch(inputFile));
    }
    
}