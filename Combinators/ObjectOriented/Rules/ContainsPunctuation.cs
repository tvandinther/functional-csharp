using Combinators.ObjectOriented.GenericRules;

namespace Combinators.ObjectOriented.Rules;

public class ContainsPunctuation : Contains<string, char>
{
    private static readonly char[] Punctuation = ".,?!:;\"\'~-/".ToCharArray();

    public ContainsPunctuation() : base(Punctuation) { }
}