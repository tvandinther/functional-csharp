namespace FunctionComposition;

public static class LINQExtensions
{
    public static T2 Select<T1, T2>(this T1 x, Func<T1, T2> f) => f(x);
}