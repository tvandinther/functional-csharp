namespace Combinators.ObjectOriented.Combinators;

public class IfElse<T> : IValidationRule<T>
{
    private readonly IValidationRule<T> _predicate;
    private readonly IValidationRule<T> _consequent;
    private readonly IValidationRule<T> _alternative;

    public IfElse(IValidationRule<T> predicate, IValidationRule<T> consequent, IValidationRule<T> alternative)
    {
        _predicate = predicate;
        _consequent = consequent;
        _alternative = alternative;
    }
    
    public bool Validate(T value) => 
        _predicate.Validate(value) ? _consequent.Validate(value) : _alternative.Validate(value);
}