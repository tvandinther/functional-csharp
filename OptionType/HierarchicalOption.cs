namespace OptionType;

// HierarchicalOption T = Some T | None

public abstract class HierarchicalOption<T>
{
    public HierarchicalOption<T2> Select<T2>(Func<T, T2> f) =>
        this switch
        {
            Some<T> a => new Some<T2>(f(a.Value)),
            None<T> => new None<T2>(),
        };
}

public class Some<T> : HierarchicalOption<T>
{
    public T Value { get; }

    public Some(T value)
    {
        Value = value;
    }
}

public class None<T> : HierarchicalOption<T>
{
    public None() { }
}