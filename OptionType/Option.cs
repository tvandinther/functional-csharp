namespace OptionType;

public class Option<T>
{
    private T Value { get; }
    private readonly bool _hasValue;
    public static Option<T> None => new();

    private Option(T value)
    {
        Value = value;
        _hasValue = true;
    }

    private Option()
    {
        _hasValue = false;
    }
    
    public static implicit operator Option<T>(T value) => new(value);

    public T2 Match<T2>(Func<T, T2> some, Func<T2> none)
    {
        return _hasValue ? some(Value) : none();
    }
    
    public Option<T2> Select<T2>(Func<T, T2> func)
    {
        return _hasValue ? new Option<T2>(func(Value)) : new Option<T2>();
    }
}