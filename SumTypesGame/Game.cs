using System.Diagnostics;

namespace SumTypesGame;

public class Game
{
    private readonly int _roundCount;

    public Game(int roundCount)
    {
        _roundCount = roundCount;
    }
    
    /*
     * Any specific game state can be switched on and processed accordingly.
     * UnreachableException is used to express that all possible patterns have been matched.
     * Unfortunately, C# does not differentiate between total and partial functions.
     * Therefore, a default case is always expected.
     * This language limitation allows issues to leak out at compile-time and presents the biggest downside to this approach.
     */
    public GameState Process(GameState state) => state switch
    {
        Initial {Data: var d} => NewRound(d),
        InProgress s => ProcessInProgress(s),
        // A completed state transitions to itself
        Completed => state,
        _ => throw new UnreachableException()
    };

    /*
     * Note that a transition function only accepts the type of state it can process.
     * This prevents the linkage of unrelated states.
     */
    private GameState ProcessInProgress(InProgress state) => state switch
    {
        PlayerTurn s => Turn.Process(s),
        EndOfRound {Data: {Rounds: var r} d} when r.Count == _roundCount  => Conclude(d),
        EndOfRound {Data: var d}  => NewRound(d),
        _ => throw new UnreachableException()
    };

    private static DrawPhase NewRound(GameData d) => 
        new(d with {Rounds = d.Rounds.Add(new Round(0, 0))}, d.Player1);
    
    private static Completed Conclude(GameData d) => 
        d.Player1.Score == d.Player2.Score 
            ? new Draw(d) 
            : new Winner(d, d.Player1.Score > d.Player2.Score ? d.Player1 : d.Player2);
}