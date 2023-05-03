namespace Combinators.ObjectOriented.GenericRules;

public class Contains<T, TK> : IValidationRule<T> where T : IEnumerable<TK>
{
    private readonly IEnumerable<TK> _values;

    public Contains(IEnumerable<TK> values)
    {
        _values = values;
    }
    
    public bool Validate(T value) => value.Any(s => _values.Contains(s));
}