using Combinators.ObjectOriented.GenericRules;

namespace Combinators.ObjectOriented.Rules;

public class AtLeast8Characters : LengthAtLeast<string, char>
{
    public AtLeast8Characters() : base(8) { }
}