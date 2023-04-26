namespace FunctionComposition;

public static class Extensions {
    /*
     * This extension method is our eager composition helper.
     * It will take a value and a function and apply the function to the value.
     */
    public static T2 Then<T1, T2>(this T1 x, Func<T1, T2> f) => f(x);
    
    /*
     * This extension method is our lazy composition helper.
     * It will take two functions and return a new function that will apply the second function to the result of the first function.
     * (g ∘ f)(x) == g(f(x))
     */
    public static Func<T1, T3> ThenLazily<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g) => x => g(f(x));
}