namespace OptionType;

/*
 * "Right is right". This is a common phrase in functional programming. It means that the right side of an Either
 * is the "correct" side. The left side is the "wrong" side. TLeft will contain some kind of error type. This is why
 * Select is defined for TRight. This opens up a can of worms for mapping either types though. If you are interested,
 * look up "control arrows".
 */
public abstract class HierarchicalEither<TLeft, TRight>
{
    public HierarchicalEither<TLeft, TRight2> Select<TRight2>(Func<TRight, TRight2> f) =>
        this switch
        {
            Left<TLeft, TRight> a => new Left<TLeft, TRight2>(a.Value),
            Right<TLeft, TRight> b => new Right<TLeft, TRight2>(f(b.Value)),
        };
}

public class Left<TLeft, TRight> : HierarchicalEither<TLeft, TRight>
{
    public TLeft Value { get; }

    public Left(TLeft value)
    {
        Value = value;
    }
}

public class Right<TLeft, TRight> : HierarchicalEither<TLeft, TRight>
{
    public TRight Value { get; }

    public Right(TRight value)
    {
        Value = value;
    }
}