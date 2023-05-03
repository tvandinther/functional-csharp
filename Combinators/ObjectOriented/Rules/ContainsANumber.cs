using Combinators.ObjectOriented.GenericRules;

namespace Combinators.ObjectOriented.Rules;

public class ContainsANumber : Contains<string, char>
{
    private static readonly char[] Numbers = "0123456789".ToCharArray();
    
    public ContainsANumber() : base(Numbers) { }
}