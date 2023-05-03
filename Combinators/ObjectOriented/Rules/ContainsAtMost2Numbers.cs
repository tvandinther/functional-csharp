namespace Combinators.ObjectOriented.Rules;

public class ContainsAtMost2Numbers : IValidationRule<string>
{
    private const string Numbers = "0123456789";

    public bool Validate(string value) => 
        value.Count(s => Numbers.Contains(s)) < 3;
}