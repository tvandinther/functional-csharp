namespace SumTypesGame;

/*
 * All legal game states are represented using a hierarchy of types.
 * States can be arranged into a tree, where only leaves are valid states.
 * All types are marked as abstract unless they are leaves in which case they are marked as sealed.
 * This is so that only valid states can be represented.
 */
public abstract record GameState(GameData Data);

public sealed record Initial(string Player1Name, string Player2Name) : GameState(GameData.Initial(Player1Name, Player2Name));
public abstract record InProgress(GameData Data) : GameState(Data);
public abstract record Completed(GameData Data) : GameState(Data);


public abstract record PlayerTurn(GameData Data, Player Player) : InProgress(Data);
public sealed record EndOfRound(GameData Data) : InProgress(Data);

public sealed record DrawPhase(GameData Data, Player Player) : PlayerTurn(Data, Player);
public sealed record ActionPhase(GameData Data, Player Player) : PlayerTurn(Data, Player);


public sealed record Draw(GameData Data) : Completed(Data);
public sealed record Winner(GameData Data, Player Player) : Completed(Data);