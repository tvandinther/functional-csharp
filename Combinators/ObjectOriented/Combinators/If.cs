namespace Combinators.ObjectOriented.Combinators;

public class If<T> : IValidationRule<T>
{
    private readonly IValidationRule<T> _predicate;
    private readonly IValidationRule<T> _consequent;

    public If(IValidationRule<T> predicate, IValidationRule<T> consequent)
    {
        _predicate = predicate;
        _consequent = consequent;
    }
    
    public bool Validate(T value) => 
        !_predicate.Validate(value) || _consequent.Validate(value);
}