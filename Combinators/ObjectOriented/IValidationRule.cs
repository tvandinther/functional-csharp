namespace Combinators.ObjectOriented;

public interface IValidationRule<T>
{
    public bool Validate(T value);
}