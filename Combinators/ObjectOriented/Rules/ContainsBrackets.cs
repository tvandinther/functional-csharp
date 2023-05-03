using Combinators.ObjectOriented.GenericRules;

namespace Combinators.ObjectOriented.Rules;

public class ContainsBrackets : Contains<string, char>
{
    private static readonly char[] Brackets = "()[]{}".ToCharArray();
    
    public ContainsBrackets() : base(Brackets) { }
}