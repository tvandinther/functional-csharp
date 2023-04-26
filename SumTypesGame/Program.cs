using System.Diagnostics;
using SumTypesGame;

const int roundCount = 5;
Console.WriteLine($"Starting a game with {roundCount} rounds.");

var game = new Game(roundCount);
GameState state = new Initial("Player 1", "Player 2");

/*
 * The game loop can be expressed as a simple state machine.
 * While the state machine has not been halted, state continues to be processed.
 */
while(state is not Completed)
{
    state = game.Process(state);
}

var resultString = state switch
{
    Draw {Data: {Player1.Name: var p1, Player2.Name: var p2}} => $"The game ended in a draw between {p1} and {p2}!",
    Winner {Player: var p} => $"{p.Name} won the game with a score of {p.Score}!",
    _ => throw new UnreachableException()
};

Console.WriteLine(resultString);
Console.WriteLine(state);