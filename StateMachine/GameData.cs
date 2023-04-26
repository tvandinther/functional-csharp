using System.Collections.Immutable;

namespace StateMachine;

public readonly record struct GameData(Player Player1, Player Player2, IImmutableList<Round> Rounds)
{
    // This is a convenience operator that allows for the extraction of the data from a GameState.
    // E.g. GameData data = new Initial("Player 1", "Player 2");
    // Equivalence: GameData data = (new Initial("Player 1", "Player 2")).Data;
    public static implicit operator GameData(GameState state) => state.Data;
    
    // This is a static factory method that allows for the creation of the initial GameData object.
    public static GameData Initial(string player1Name, string player2Name) => new(
        new Player(player1Name),
        new Player(player2Name),
        ImmutableList<Round>.Empty
        );
};

public readonly record struct Player(string Name, int Score = 0);

public readonly record struct Round(int Data1, int Data2);