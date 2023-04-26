using System.Diagnostics;

namespace SumTypesGame;

internal static class Turn { 
    public static GameState Process(PlayerTurn turn) => turn switch
    {
        // After the draw phase, the same player gets to take an action
        DrawPhase {Player: var p, Data: var d} => 
            new ActionPhase(d with {}, p),
        
        // The game is rigged so that Player 1 always gets a point
        ActionPhase {Player: var p, Data: var d} when p == d.Player1 => 
            new DrawPhase(d with { Player1 = p with {Score = p.Score + 1}}, d.Player2),
        
        // After player 2's action phase, the round ends
        ActionPhase {Player: var p, Data: var d} when p == d.Player2 => 
            new EndOfRound(d),
        
        _ => throw new UnreachableException()
    };
}