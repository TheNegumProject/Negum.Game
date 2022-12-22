using Negum.Game.Common.States.Packets;

namespace Negum.Game.Common.States;

/// <summary>
/// Responsible for operating on <see cref="GameState"/>.
/// </summary>
public interface IGameStateProvider
{
    /// <summary>
    /// </summary>
    /// <returns><see cref="GameState"/> of the current game.</returns>
    GameState GetGameState();

    /// <summary>
    /// Updates (overwrites) local <see cref="GameState"/>. <br />
    /// This is mainly called after successful response from <see cref="SyncStatePacket"/>. <br />
    /// It will be safer for PacketHandlers to modify <see cref="GameState"/> after calling <see cref="GetGameState"/>.
    /// </summary>
    /// <param name="gameState"></param>
    void UpdateGameState(GameState gameState);
}

public class GameStateProvider : IGameStateProvider
{
    private GameState CurrentState { get; set; } = new();
    
    public GameState GetGameState() => 
        CurrentState;

    public void UpdateGameState(GameState gameState) => 
        CurrentState = gameState;
}