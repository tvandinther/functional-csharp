namespace Combinators.Functional;

public static class GenericRules
{
    public static Func<T, bool> ContainsAny<T, TMember>(params TMember[] values) where T : IEnumerable<TMember> => 
        x => x.Any(values.Contains);

    public static Func<T, bool> ContainsAll<T, TMember>(params TMember[] values) where T : IEnumerable<TMember> =>
        x => x.All(values.Contains);
        
    public static Func<T, bool> ContainsWith<T, TMember>(Func<IEnumerable<TMember>, bool> rule, params TMember[] values) where T : IEnumerable<TMember> => 
        x => rule(x.Where(values.Contains));
    
    public static Func<T, bool> ContainsNone<T, TMember>(params TMember[] values) where T : IEnumerable<TMember> =>
        x => x.All(s => !values.Contains(s));
    
    public static Func<T, bool> ContainsExactly<T, TMember>(int n, params TMember[] values) where T : IEnumerable<TMember> =>
        x => x.Count(values.Contains) == n;
    
    public static Func<T, bool> ContainsAtLeast<T, TMember>(int n, params TMember[] values) where T : IEnumerable<TMember> =>
        x => x.Count(values.Contains) >= n;
    
    public static Func<T, bool> ContainsAtMost<T, TMember>(int n, params TMember[] values) where T : IEnumerable<TMember> =>
        x => x.Count(values.Contains) <= n;
    
    public static Func<T, bool> LengthAtLeast<T, TMember>(int n) where T : IEnumerable<TMember> =>
        x => x.Count() >= n;
}