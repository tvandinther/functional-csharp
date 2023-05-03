using Combinators.ObjectOriented.GenericRules;

namespace Combinators.ObjectOriented.Rules;

public class Contains2Symbols : ContainsExactly<string, char>
{
    private static readonly char[] Symbols = "@#$%^&*|\\+=<>".ToCharArray();
    
    public Contains2Symbols() : base(2, Symbols) { }
}