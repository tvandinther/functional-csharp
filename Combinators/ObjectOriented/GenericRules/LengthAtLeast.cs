namespace Combinators.ObjectOriented.GenericRules;

public class LengthAtLeast<T, TK> : IValidationRule<T> where T : IEnumerable<TK>
{
    private readonly int _length;

    public LengthAtLeast(int length)
    {
        _length = length;
    }

    public bool Validate(T value) => value.Count() >= _length;
}