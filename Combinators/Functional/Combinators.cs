namespace Combinators.Functional;

public static class Combinators
{
    /*
     * Collapses all booleans (from predicates) with the AND operator.
     */
    public static Func<T, bool> All<T>(params Func<T, bool>[] rules) => 
        x => rules.All(f => f(x));

    /*
     * Collapses all booleans (from predicates) with the OR operator.
     */
    public static Func<T, bool> Any<T>(params Func<T, bool>[] rules) => 
        x => rules.Any(f => f(x));

    /*
     * Collapses all booleans (from predicates) with the AND operator and a negation.
     */
    public static Func<T, bool> None<T>(params Func<T, bool>[] rules) => 
        x => !rules.All(f => f(x));

    /*
     * Negates a predicate.
     */
    public static Func<T, bool> Not<T>(Func<T, bool> rule) => 
        x => !rule(x);

    /*
     * Evaluates to the consequent if the predicate is false, otherwise evaluates to true.
     */
    public static Func<T, bool> If<T> (Func<T, bool> predicate, Func<T, bool> consequent) => 
        x => !predicate(x) || consequent(x);

    /*
     * Evaluates to the consequent if the predicate is true, otherwise evaluates to the alternative.
     * Equivalent to: (predicate AND consequent) OR (NOT predicate AND alternative)
     */
    public static Func<T, bool> IfElse<T>(Func<T, bool> predicate, Func<T, bool> consequent, Func<T, bool> alternative) => 
        x => predicate(x) ? consequent(x) : alternative(x);
}