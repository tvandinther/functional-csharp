namespace Combinators.ObjectOriented.GenericRules;

public class ContainsAtMost<T, TK> : IValidationRule<T> where T : IEnumerable<TK>
{
    private readonly int _n;
    private readonly IEnumerable<TK> _values;

    public ContainsAtMost(int n, IEnumerable<TK> values)
    {
        _n = n;
        _values = values;
    }
    
    public bool Validate(T value) =>
        value.Count(_values.Contains) <= _n;
}