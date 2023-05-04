namespace OptionType;

/*
 * "Right is right". This is a common phrase in functional programming. It means that the right side of an Either
 * is the "correct" side. The left side is the "wrong" side. TLeft will contain some kind of error type. This is why
 * Select is defined for TRight. This opens up a can of worms for mapping either types though. If you are interested,
 * look up "control arrows".
 */
public class Either<TLeft, TRight>
{
    private TLeft Left { get; }
    private TRight Right { get; }
    private readonly bool _isLeft;
    
    private Either(TLeft left)
    {
        Left = left;
        _isLeft = true;
    }
    
    private Either(TRight right)
    {
        Right = right;
        _isLeft = false;
    }

    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left);
    public static implicit operator Either<TLeft, TRight>(TRight right) => new(right);
    
    public T Match<T>(Func<TLeft, T> left, Func<TRight, T> right) => 
        _isLeft ? left(Left) : right(Right);

    public Either<TLeft, TRight2> Select<TRight2>(Func<TRight, TRight2> func) => 
        _isLeft ? new Either<TLeft, TRight2>(Left) : new Either<TLeft, TRight2>(func(Right));
}